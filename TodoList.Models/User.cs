using Newtonsoft.Json;

namespace TodoList.Models;
public class User
{
    public User(string keyId,string name,string lastName,string password)
    {
        KeyId = keyId;
        Name = name;
        LastName = lastName;
        Password = password;
        UserTodoList = new List<Issue>();
    }
    
    public string KeyId{get;}
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
       user.UserTodoList.Add(newIssue);
        var filePath = path;
// Read existing json data
        var jsonData = GetJsonData(filePath);
// De-serialize to object or create new list
        var usersList = DeserializeUser(filePath);

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
    public static void DeleteIssue(int number,string pathJson,User user){
        var usersList = DeserializeUser(pathJson);
        if(number <= 0 || number > user.UserTodoList.Count){
            System.Console.WriteLine("Enter right value");
        }
        else{
            foreach(var us in usersList){
                if(us.KeyId == user.KeyId){
                    us.UserTodoList.RemoveAt(number - 1);
                    user.UserTodoList.RemoveAt(number - 1);
                    SerializeAndWrite(usersList,pathJson);
                    System.Console.WriteLine("User sucessfully deleted!");
                    break;
                }
                
            }
            

        }
    }
    public static List<User> DeserializeUser(string path){

        var filePath = path;
// Read existing json data
        var jsonData = GetJsonData(filePath);
// De-serialize to object or create new list
        var usersList = JsonConvert.DeserializeObject<List<User>>(jsonData) 
                      ?? new List<User>();
        return usersList;
    }
    public static void SerializeAndWrite(List<User> usersList,string filePath){
        var jsonData = JsonConvert.SerializeObject(usersList,Formatting.Indented);
        System.IO.File.WriteAllText(filePath, jsonData);
    }
    public static string GetJsonData(string pathFile){
    var jsonData = System.IO.File.ReadAllText(pathFile);
    return jsonData;
    }
}