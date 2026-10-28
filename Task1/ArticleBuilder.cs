using System.Collections.Generic;
public class ArticleBuilder
{
    private readonly Article article = new Article();
    public ArticleBuilder SetTitle(string title)
    {
        article.Title = title;
        return this;
    }
    public ArticleBuilder SetAuthors(List<string> authors)
    {
        article.Authors = authors;
        return this;
    }
    public ArticleBuilder SetText(string text)
    {
        article.Text = text;
        return this;
    }
    public ArticleBuilder SetHash(string hash)
    {
        article.Hash = hash;
        return this;
    }
    public Article Build()
    {
        return article;
    }
}