using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace MiniSocialMedia
{
    class SocialException : Exception
    {
        public SocialException(string msg) : base(msg) {}
        public SocialException(string msg, Exception inner) : base(msg, inner) {}
    }

    interface IPostable
    {
        public void AddPost(string content);
        public IReadOnlyList<Post> GetPosts();
    }

    public class Post
    {
        public string AuthorUserName{get; init;}
        public string Content{get; init;}
        public DateTime CreatedAt{get; init;} = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if(author == null)
                throw new ArgumentException("Argument exception", nameof(author));
            AuthorUserName = author.Username;
            Content = content;
        }

        public override string ToString()
        {
            string pattern = @"#\p{L}+";
            var res = Regex.Matches(Content!, pattern);
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"@{AuthorUserName} • {CreatedAt.FormatTimeAgo()}");
            sb.AppendLine(Content);

            if(res.Count > 0){
                sb.Append("Tags: ");
                sb.AppendJoin(", ", res.Cast<Match>().Select(m => m.Value));
            }
            
            return sb.ToString();
        }
    }

    public partial class User : IPostable, IComparable<User>
    {
        public string Username{get; init;}
        public string Email{get; init;}
        private List<Post> _post = new List<Post>();
        private HashSet<string> _following = new (StringComparer.OrdinalIgnoreCase);
        public List<Post> Post => _post;
        public List<string> Following => _following.ToList();
        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if(string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(nameof(username));
            
            string pattern = @"\b[\w.-]+@[\w]+\.\w{2,}\b";
            bool flag = Regex.IsMatch(email, pattern);

            if(!flag)
                throw new SocialException($"invalid email format");
            
            username = username.Trim();
            Username = username;
            email = email.Trim().ToLower();
            Email = email;
        }
        
        public void Follow(string userToFollow)
        {
            if (userToFollow == null)
                throw new SocialException("User to follow can't be null");

            if (string.Equals(userToFollow, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(userToFollow.Trim());
        }

        public bool IsFollowing(string username) => _following.Contains(username);

        public void AddPost(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
                throw new ArgumentException(nameof(content));
            
            if(content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");
            
            content = content.Trim();
            Post p = new Post(this, content);
            _post.Add(p);
            OnNewPost?.Invoke(p);
        }

        public IReadOnlyList<Post> GetPosts()
        {
            return _post.AsReadOnly();
        }

        public int CompareTo(User? other)
        {
            if(other == null)
                return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }

    class Repository<T> where T : class
    {
        private List<T> _items = new();
        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T? Find(Predicate<T> match) => _items.Find(match);
    }

    static class SocialUtils{
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;          // timestamp
            if (diff.TotalSeconds < 60)
                return "just now";
            else if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";
            else if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} hr ago";
            else
                return time.ToString("MMM dd");
        }
    }

    public class Program
    {
        private static Repository<User> _users = new();
        private static User? _currentUser = null;
        private static string? _dataFile = "user.json";

        public static void ShowLoginMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Register();
                        Console.WriteLine();
                        break;
                    case 2:
                        Login();
                        if(_currentUser != null)
                            return;
                        Console.WriteLine();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid menu choices");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public static void Register()
        {
            Console.Write("Enter your username: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;
            
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email)){
                Console.WriteLine("Invalid");
                return;
            }
            
            var existingUser = _users.Find(e => e.Username.Equals(name, StringComparison.OrdinalIgnoreCase));

            if(existingUser != null){
                Console.WriteLine("Username exists");
                return;
            }
            
            User user = new User(name, email);
            _users.Add(user);
            Console.WriteLine($"Welcome user {name}");
        }

        public static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            var user = _users.Find(e => e.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if(user == null){
                Console.WriteLine("user doesn't exists");
                return;
            }
            _currentUser = user;

            Action<Post> OnPostCreate = post => Console.WriteLine($"new post from: {post.AuthorUserName}");
            _currentUser.OnNewPost += OnPostCreate;

            Console.WriteLine("Login confirmed");
            return;
        }

        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Post message");
                Console.WriteLine("2. View own post");
                Console.WriteLine("3. View timeline");
                Console.WriteLine("4. Follow user");
                Console.WriteLine("5. List user");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit and Save");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        PostMessage();
                        Console.WriteLine();
                        break;
                    case 2:
                        ShowPosts();
                        Console.WriteLine();
                        break;
                    case 3:
                        ShowTimeLine();
                        Console.WriteLine();
                        break;
                    case 4:
                        FollowUser();
                        Console.WriteLine();
                        break;
                    case 5:
                        ListUsers();
                        Console.WriteLine();
                        break;
                    case 6:
                        _currentUser = null;
                        Console.WriteLine();
                        return;
                    case 7:
                        SaveData();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Incorrect choice");
                        // throw new SocialException("invalid choice");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public static void PostMessage()
        {
            if(_currentUser != null)
            {
                Console.Write("Enter your post msg: ");
                string msg = Console.ReadLine()!;
                if(string.IsNullOrWhiteSpace(msg)) return;

                _currentUser.AddPost(msg);
                Console.WriteLine("Post confirmed");
            } else
            {
                Console.WriteLine("Login first");
            }
        }

        public static void ShowTimeLine()
        {
            if (_currentUser == null)
            {
                Console.WriteLine("Login first");
                return;
            }

            List<Post> timeline = new List<Post>();
            timeline.AddRange(_currentUser.GetPosts());

            foreach (var user in _users.GetAll())
            {
                if (_currentUser.IsFollowing(user.Username))
                    timeline.AddRange(user.GetPosts());
            }

            if (timeline.Count == 0)
            {
                Console.WriteLine("Timeline is empty");
                return;
            }

            foreach (var post in timeline.OrderByDescending(p => p.CreatedAt))
            {
                Console.WriteLine(post);
                Console.WriteLine();
            }
        }

        public static void ShowPosts()
        {
            if(_currentUser == null){
                Console.WriteLine("Login first");
                return;
            }
            var post = _currentUser.GetPosts();
            if(post.Count == 0)
                Console.WriteLine("No post");
            foreach(var it in post){
                Console.WriteLine(it);
                Console.WriteLine();
            }
        }

        public static void FollowUser()
        {
            if(_currentUser != null)
            {
                Console.Write("Enter user to follow: ");
                string userToFollow = Console.ReadLine()!;
                if(string.IsNullOrWhiteSpace(userToFollow))   return;
                if(string.Equals(userToFollow, _currentUser.Username, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("can't follow on yourself");
                    return;
                }
                var targetUser = _users.Find(u => u.Username.Equals(userToFollow, StringComparison.OrdinalIgnoreCase));
                if(targetUser == null){
                    Console.WriteLine("Target User not found");
                    return;
                }
                
                _currentUser.Follow(targetUser!.Username);
                Console.WriteLine("user followed");
            }
        }

        public static void ListUsers()
        {
            var allUser = _users.GetAll();
            var sortedList = allUser.OrderBy(e => e.Username).ToList();
            foreach(var it in sortedList)
                Console.WriteLine(it.GetDisplayName());
        }

        //* IMPORTANT
        public static void SaveData()
        {
            try
            {
                var users = _users.GetAll();
                var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(_dataFile!, json);
            } 
            catch(Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to saved data");
            }
        }

        public static void LoadData()
        {
            if(!File.Exists(_dataFile))
                return;

            try
            {
                var json = File.ReadAllText(_dataFile);
                var users = JsonSerializer.Deserialize<List<User>>(json);

                if (users == null) return;

                foreach (var user in users)
                    _users.Add(user);
            } 
            catch(Exception ex)
            {
                LogError(ex);
            }
        }

        public static void LogError(Exception ex)
        {
            File.AppendAllText(
                "error.log",
                DateTime.Now + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine
            );
        }

        public static void ConsoleColorWrite()
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== miniSocial ===");
            Console.ForegroundColor = originalColor;
        }

        public static void main()
        {
            Console.WriteLine("MiniSocial - Console Edition");
            ConsoleColorWrite();
            LoadData();
            while (true)
            {
                try
                {
                    if(_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                } 
                catch(SocialException ex)
                {
                    LogError(ex);
                    Console.WriteLine("Error: " + ex.Message);
                } 
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }

    public class UserExtensions
    {
        public void GetFollowingName()
        {
            
        }
    }

}