using System;
using System.Collections.Generic;

static class StringExtensions
{
    public static string[] DistinctById(this string[] items)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> res = new List<string>();

        foreach (var item in items)
        {
            var p = item.Split(':');
            string id = p[0];
            string name = p[1];

            if (!seen.Contains(id))
            {
                seen.Add(id);
                res.Add(name);
            }
        }

        return res.ToArray();
    }
}