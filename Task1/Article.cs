using System.Collections.Generic;

public class Article
{
    public string Title { get; set; } = "";
    public List<string> Authors { get; set; } = new();
    public string Text { get; set; } = "";
    public string Hash { get; set; } = "";
    public bool HashValid { get; set; }
}