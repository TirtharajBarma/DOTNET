using System;
using System.Text.RegularExpressions;

namespace LogProcessing
{
    public class LogParser{
        private string? ValidLineRegexPattern{get; set;}
        private string? SplitLineRegexPattern{get; set;}
        private string? QuotedPasswordRegexPattern{get; set;}
        private string? EndOfLineRegexPattern{get; set;}
        private string? WeekPasswordRegexPattern{get; set;}

        public static bool IsValid(string text)
        {
            string pattern = @"^\[TRC|DBG|INF|WRN|ERR|FTL\]";
            bool flag = Regex.IsMatch(text, pattern);
            return flag;
        }

        public static string[] SplitLogLine(string text)
        {
            string[] res = Regex.Split(text, @"[<^*>=]+");
            return res;
        }

        public static int CountQuotedPasswords(string lines)
        {
            if(string.IsNullOrWhiteSpace(lines))
                Console.WriteLine("string is null");
            string pattern = "password[a-zA-Z0-9]+[^\"]*";

            MatchCollection matches = Regex.Matches(lines, pattern);

            return matches.Count;
        }

        public static string RemoveEndOfLineText(string line)
        {
            if(string.IsNullOrWhiteSpace(line))
                Console.WriteLine("string is null");
            string pattern = @"end-of-line\d+";
            line = Regex.Replace(line, pattern, "");
            return line;
        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            string pattern = @"password\w+";
            string[] res = new string[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                Match m = Regex.Match(lines[i], pattern);
                if(m.Success)
                    res[i] = m.Value + ": " + lines[i];
                else
                    res[i] = "-------: " + lines[i]; 
            }
            return res;
        }
    }
}