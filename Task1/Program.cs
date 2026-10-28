using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string inputPath = "article.txt";
        string outputPath = "article.json";
        if (!File.Exists(inputPath))
        {
            string articleText =
                "Интересная лабораторная,спасибо, можно больше не надо.";

            string hash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(articleText)));

            string content =
                "Title: Порождающие паттерны\n" +
                "Authors: Шабаршов Максим\n" +
                "Text: " + articleText + "\n" +
                "Hash: " + hash + "\n";

            File.WriteAllText(inputPath, content);
        }

        ArticleConverter.ConvertFile(inputPath, outputPath);
    }
}