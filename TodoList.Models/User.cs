using Newtonsoft.Json;

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
        UserTodoList = new List<Issue>();
    }
    private static int id = 1;
    public int Id{get;}
    public string Name { get; }
    public string LastName{get;}
    public string Password{get;}
    public List<Issue> UserTodoList{get;private set;}

    public static void AddIssue(string path,User user){
        System.Console.WriteLine("Enter Title:");
        string title = Console.ReadLine();
        System.Console.WriteLine("Enter Description");
        string description = Console.ReadLine();
        var newIssue = new Issue(title,description);
       
        var filePath = path;
// Read existing json data
        var jsonData = System.IO.File.ReadAllText(filePath);
// De-serialize to object or create new list
        var usersList = JsonConvert.DeserializeObject<List<User>>(jsonData) 
                      ?? new List<User>();

        foreach(var us in usersList){
            if(us.Name == user.Name){
                us.UserTodoList.Add(newIssue);
                System.Console.WriteLine("new issue added succsessfully!");
                jsonData = JsonConvert.SerializeObject(usersList,Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonData);
                break;
            }
        }

// Update json data string


    }
}