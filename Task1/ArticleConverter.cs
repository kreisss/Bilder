using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class ArticleConverter
{
    public static void ConvertFile(string inputPath, string outputPath)
    {
        string[] lines = File.ReadAllLines(inputPath);

        string title = "";
        string authors = "";
        string text = "";
        string hash = "";

        foreach (string line in lines)
        {
            if (line.StartsWith("Title:"))
                title = line.Substring(6).Trim();
            else if (line.StartsWith("Authors:"))
                authors = line.Substring(8).Trim();
            else if (line.StartsWith("Text:"))
                text = line.Substring(5).Trim();
            else if (line.StartsWith("Hash:"))
                hash = line.Substring(5).Trim();
        }

        string calculatedHash = Convert.ToHexString(
            SHA256.HashData(Encoding.UTF8.GetBytes(text)));

        bool isValid = string.Equals(
            hash, calculatedHash, StringComparison.OrdinalIgnoreCase);

        Article article = new ArticleBuilder()
            .SetTitle(title)
            .SetAuthors(authors.Split(',')
                .Select(a => a.Trim()).ToList())
            .SetText(text)
            .SetHash(hash)
            .Build();

        article.HashValid = isValid;

        string json = JsonSerializer.Serialize(article,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(outputPath, json);

        Console.WriteLine("Финито ля программо.");
        Console.WriteLine("Хеш корректен: " + isValid);
        Console.WriteLine("Результат сохранён в " + outputPath);
    }
}