using System;

namespace DialingCodesApp
{
    public static class DialingCodes
    {   
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            Dictionary<int, string> country = new Dictionary<int, string>();
            return country;
        }

        public static Dictionary<int, string> GetExistingDictionary()
        {
            Dictionary<int, string> country = new Dictionary<int, string>();
            country[1] = "United States of America";
            country[55] = "Brazil";
            country[91] = "India";

            return country;
        }

        public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int CountryCode)
        {
            if(existingDictionary.ContainsKey(CountryCode))
                return existingDictionary[CountryCode];
            else    
                return "";
        }

        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        {
            if(existingDictionary.ContainsKey(countryCode))
                return true;
            else
                return false;
        }

        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            if(existingDictionary.ContainsKey(countryCode))
                existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        public static Dictionary<int, string> RemoveCountryFromDictionary(Dictionary<int, string> existingDictionary, int countryCode)
        {
            if(existingDictionary.ContainsKey(countryCode))
                existingDictionary.Remove(countryCode);
            return existingDictionary;
        }

        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            int maxi = 0;
            string country = "";
            foreach(var it in existingDictionary.Values)
            {
                if(it.Length > maxi)
                {
                    maxi = it.Length;
                    country = it;
                }
            }
            return country;
        }

        public static void PrintDictionary(Dictionary<int, string> existingDictionary)
        {
            foreach(var it in existingDictionary)
                Console.WriteLine($"code: {it.Key}, Country: {it.Value}");
        }
    }

    class Program
    {
        public static void main()
        {
            DialingCodes.GetEmptyDictionary();
            DialingCodes.GetExistingDictionary();

        }
    }
}