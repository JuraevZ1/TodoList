



using System.Text.Json;
using Newtonsoft.Json;
using TodoList.Models;

namespace TodoList.Logic;
public static class TodoMain
{
    public const string path = @"..\FilesLikeDB\users.json";
    
    public static void Start(){
        
        System.Console.WriteLine("<<<<TODO.NEt>>>>");
        System.Console.WriteLine("1.Sign in\n2.Sign up\n3.Exit");
        switch(WhileLoop(3)){
            case 1:
                System.Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                User checkUser = SigIn(name,password);
                if(checkUser != null){
                    System.Console.WriteLine("Welcome " + checkUser.Name);
                    
                    Welcome(checkUser);
                    System.Console.WriteLine("1.Add Issue\n2.Remove Issue\n3.Exit");
                  switch(WhileLoop(3)){
                        case 1:
                        User.AddIssue(path,checkUser);
                        break;
                        case 2:
                        System.Console.WriteLine("Enter number of Issue:");
                        int number = int.Parse(Console.ReadLine());
                        User.DeleteIssue(number,path,checkUser);
                        break;
                  }
                }
                else{
                    System.Console.WriteLine("Password or name isnt true");
                }
                break;
            case 2:
                System.Console.WriteLine("Sign up");
                AddNewUser(path);
                break;
            case 3:
                System.Console.WriteLine("Exit");
                break;
        }
    }
    public static User SigIn(string name,string password){
        User res = null;
       
        
       foreach(var user in DeserializeUsers(path)){
        if(user.Name == name && user.Password == password){
            res = user;
            break;
        }
       }
       return res;
    }
    public static void Welcome(User user){
        int i = 0;
        if(user.UserTodoList != null){
            foreach(var issue in user.UserTodoList){
               
                System.Console.WriteLine($"{++i})Title: " + issue.Title + "\nDescription: " + issue.Description);
                System.Console.WriteLine("Added date:  " + issue.CreatedDate.Date);
                System.Console.WriteLine("---------------------------------------------");
            }
        }
        else{
            System.Console.WriteLine("you havent issues yet");
        }
    }
    public static int WhileLoop(int countOperations){
        
        int input = 0;
        while(input <= 0 || input > countOperations){
            
             int.TryParse(Console.ReadLine(),out input);
        }
        return input;
        
    }
    public static List<User> DeserializeUsers(string pathJson){
       
       using StreamReader streamReader = new(path);
       var json = streamReader.ReadToEnd();
       var users = JsonConvert.DeserializeObject<List<User>>(json);
       return users;
    }
    public static void AddNewUser(string pathJsonFile){
        System.Console.WriteLine("Add key id:");
        string keyId = Console.ReadLine();
        System.Console.WriteLine("Enter your Name:");
        string name = Console.ReadLine();
        System.Console.WriteLine("Enter your LastName");
        string lastName = Console.ReadLine();
        System.Console.WriteLine("Enter password:");
        string password = Console.ReadLine();
        var newUser = new User(keyId,name,lastName,password);
        var usersList = User.DeserializeUser(pathJsonFile);
        usersList.Add(newUser);
        User.SerializeAndWrite(usersList,pathJsonFile);
        System.Console.WriteLine("successfully created your account");
    }
}
