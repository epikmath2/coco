// See https://aka.ms/new-console-template for more information
public class Program{
    string[]  vars;
        void ECHO(string stri){
        Console.WriteLine(stri);
    }
    public void parseCommand(string command, string[] args){
        switch (command)
        {
            case "ECHO":
                ECHO(args[0]);
                break;
            case "STORE"
            default:

            break;
        }
    }
}