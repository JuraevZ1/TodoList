namespace TodoList.Models;
public class Issue
{
    public Issue(string title,string description)
    {
        Title = title;
        Description = description;
        
    }
    public string Title { get; set; }
    public DateTime CreatedDate{get;private set;}
    public string Description{get;set;}
}
