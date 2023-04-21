



using System.Text.Json;
using TodoList.Models;

namespace TodoList.Logic;
public static class TodoMain
{
    public const string path = @"..\FilesLikeDB\users.json";
    public static void Start(){
        int startInput = 0;
        while(startInput <= 0 || startInput > 3){
        Console.Clear();
        System.Console.WriteLine("<<<<TODO.NEt>>>>");
        System.Console.WriteLine("1.Sign in\n2.Sign up\n3.Exit");
           int.TryParse(Console.ReadLine(),out startInput);
        }
        switch(startInput){
            case 1:
                System.Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                User checkUser = SigIn(name,password);
                if(checkUser != null){
                    System.Console.WriteLine("Welcome " + checkUser.Name);
                    
                    Welcome(checkUser);
                }
                else{
                    System.Console.WriteLine("Password or name isnt true");
                }
                break;
            case 2:
                System.Console.WriteLine("Sign up");
                break;
            case 3:
                System.Console.WriteLine("Exit");
                break;
        }
    }
    public static User SigIn(string name,string password){
        User res = null;
       using StreamReader streamReader = new(path);
       var json = streamReader.ReadToEnd();
       List<User> users = JsonSerializer.Deserialize<List<User>>(json);
       
        
       foreach(var user in users){
        if(user.Name == name && user.Password == password){
            res = user;
            break;
        }
       }
       return res;
    }
    public static void Welcome(User user){
        if(user.UserTodoList != null){
            foreach(var issue in user.UserTodoList){
                System.Console.WriteLine(issue.Title + "\n" + issue.Description);
                System.Console.WriteLine();
            }
        }
        else{
            System.Console.WriteLine("you havent issues yet");
        }
    }
    
}
