using System;
using System.Collections.Generic;
using System.Text.Json;

public record Student(string Name, int Score);

class Solution
{
    public static string BuildJson(string[] items, int minScore)
    {
        List<Student> list = new List<Student>();

        foreach (var item in items)
        {
            var p = item.Split(':');
            string name = p[0];
            int score = int.Parse(p[1]);

            if (score >= minScore)
                list.Add(new Student(name, score));
        }

        list.Sort((a, b) =>
        {
            int c = b.Score.CompareTo(a.Score);
            return c != 0 ? c : a.Name.CompareTo(b.Name);
        });

        return JsonSerializer.Serialize(list);
    }
}