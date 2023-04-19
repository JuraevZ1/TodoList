namespace TodoList.Models;
public class User
{
    public User(string name,string lastName,string password)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Password = password;
        id+=1;
        UserTodoList = new Stack<Issue>();
    }
    private static int id = 1;
    public int Id{get;}
    public string Name { get; }
    public string LastName{get;}
    public string Password{get;}
    public Stack<Issue> UserTodoList{get;private set;}

    public void AddIssue(Issue issue){
        UserTodoList.Push(issue);
    }
}