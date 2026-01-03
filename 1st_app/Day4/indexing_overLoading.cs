using System;

class Library
{
    private Dictionary<int, string> books = new Dictionary<int, string>();

    public string this[int bookId]
    {
        get
        {
            if (books.ContainsKey(bookId))
            {
                return books[bookId];
            }
            else
            {
                return "Book Id not found";
            }
        } 
        set
        {
            books[bookId] = value;
        }
    }

    public string this[string title]
    {
        get
        {
            var result = books.FirstOrDefault(ele => ele.Value == title);

            if(result.Key == 0 && result.Value == null)
            {
                return "Empty";
            }
            return result.Value;
        }
    }

}