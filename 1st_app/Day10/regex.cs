using System;
using System.Text.RegularExpressions;
class RegexDemo
{
    public static void cal()
    {
        // string sentence = "abc124";
        string sentence = "123_123";
        string pattern = @"\d";
        
        bool flag = Regex.IsMatch(sentence, pattern);
        Console.WriteLine(flag);

        Match m = Regex.Match("Amount: 5000 hello 600", @"\d+");
        Console.WriteLine(m.Value);

        // ^ and $
        bool flag1 = Regex.IsMatch("abcd12", @"\d$");
        bool flag2 = Regex.IsMatch("1abcd12", @"^\d");
        Console.WriteLine("$: " + flag1);
        Console.WriteLine("^: " + flag2);

        // MatchCollection match = Regex.Matches("10A20B30", @"\D");       //* non digit " A B "
        // MatchCollection match = Regex.Matches("10A20B30", @"\d+");      //* digit.    "10 20 30"
        
        // MatchCollection match = Regex.Matches("10A20B30", @"\w");       //* full string [only '_' is allowed]
        // Match match = Regex.Match("10A20B30", @"\w");      // 1
        // Match match = Regex.Match("10A20B30@", @"\W");      // 1           //* no-word character
        // Console.WriteLine(match);
        // foreach (Match item in match)
        // {
        //     Console.Write(item.Value + " ");
        // }

        //* white spaces
        // string text = "Hello World\t2025\nDone";
        // MatchCollection spaces = Regex.Matches(text, @"\s");

        // Console.WriteLine("Whitespace matches:");
        // foreach (Match it in spaces)
        //     Console.WriteLine($"[{it.Value}]");
        
        // Match match = Regex.Match("file.txt", @"\.txt");                  //*.txt
        // Match match = Regex.Match(@"C:\abc\file.txt", @"\\");             //* single '/'
        // Console.WriteLine(match.Value);
        
        // MatchCollection match = Regex.Matches(@"C:\abc\file.txt", @"\\");    //* double '//'
        // foreach (Match it in match)
        //     Console.Write($"{it.Value}");

        // Match m1 = Regex.Match("Date: 2025-12-29", @"(\d{4})-(\d{2})-(\d{2})");
        // Console.WriteLine(m1.Value);

        //* groups
        string sentence1 = "Amount=5000";
        string pattern2 = @"Amount=(?<value>\d+)";

        Match m1 = Regex.Match(sentence1, pattern2); 
        Console.WriteLine(m1.Groups["value"].Value);        //* 5000
        
        string sentence2 = "1992-02-23, 2003-09-15";
        string pattern3 = @"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})";

        Match m2 = Regex.Match(sentence2, pattern3); 
        Console.WriteLine(m2.Groups["month"].Value);        //* 02
        Console.WriteLine(m2.Groups[0].Value);  // [0] -> 1992-02-23, [1] -> 1992, [2] -> 02
        
        MatchCollection match = Regex.Matches(sentence2, pattern3);
        foreach(Match it in match)
            Console.Write(it.Groups["month"].Value + " ");
        Console.WriteLine();
        
        // Email
        List<string> Emails = new List<string>
        {
            "john.doe@gmail.com",
            "alice_123@yahoo.in",
            "mark.smith@company.com",
            "support-abc@banking.co.in",
            "user.nametag@domain.org",
            "john.doe@gmail",          // Missing domain extension
            "alice@@yahoo.com",        // Double @
            "mark.smith@.com",         // Domain missing name
            "support@banking..com",    // Double dot in domain
            "user name@gmail.com",     // Space not allowed
            "@domain.com",             // Missing username
            "admin@domain",            // No top-level domain
            "info@domain,com",         // Comma instead of dot
            "finance#dept@corp.com",   // Invalid character #
            "plainaddress"             // Missing @ and domain
        };
        string pattern4 = @"\b[\w.-]+@[\w-]+\.\w{2,}\b";
        foreach(var it in Emails)
        {
            if (Regex.IsMatch(it, pattern4))
                Console.WriteLine($"{it} is a valid email format");
            else
                Console.WriteLine($"{it} is NOT a valid email format");
        }
    }
}

// MatchCollection = [Match, Match, Match]
// \b \b