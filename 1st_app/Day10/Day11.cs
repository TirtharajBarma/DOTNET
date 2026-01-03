using System;
using System.Text.RegularExpressions;

namespace test
{
    class LogParser
    {
        public static bool LogHeader(string str)
        {
            if(string.IsNullOrWhiteSpace(str))
                return false;

            string pattern = 
            @"^\[(INFO|WARN|ERROR|DEBUG|CRITICAL\)] " +
            @"\d{4}-" + 
            @"(0[1-9]|1[0-2])-" +
            @"T" + 
            @"([01][0-9]|2[0-3]):" + 
            @"[0-5][0-9]:" +
            @"[0-5][0-9]" + 
            @"[0-5][0-9]" + 
            @"Z$";
            return Regex.IsMatch(str, pattern); 
        }
        public static Match ExtractServiceAndUser(string line)
        {
            string pattern =
                @"service=(?<service>[a-z]+)" +
                @"(?:\s+userId=(?<userId>USR_\d+))?";
            return Regex.Match(line, pattern);
        }

        public static bool IsHighRisk(string line)
        {
            string pattern =
                @"(\[(ERROR|CRITICAL)\])|" +
                @"(password)|" +
                @"(FAILED)|" +
                @"(restartCount=[3-9]\d*)";
            return Regex.IsMatch(line, pattern, RegexOptions.IgnoreCase);
        }

        public static int CountQuotedPasswords(string lines)
        {
            if (string.IsNullOrWhiteSpace(lines))
                return 0;

            string pattern = @"""password[a-zA-Z0-9]+[^""]*""";

            MatchCollection matches = Regex.Matches(
                lines,
                pattern,
                RegexOptions.IgnoreCase
            );

            return matches.Count;
        }
    }
}


// split
// replaces
// matches
// isMatch