using MongoDB.Bson;

namespace Domain.Common;

public class QuizLink
{
    public QuizLink(string itemId, string link)
    {
        Id = itemId;
        Link = link;
    }

    public string Id { get; set; }
    public string Link { get; set; }   
}