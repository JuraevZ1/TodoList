



namespace TodoList.Logic;
public static class TodoMain
{
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
                System.Console.WriteLine("HEllo");
                break;
        }
    }

}
