using System;
using System.Collections;
using System.Collections.Generic;

public class Program{
    static ArrayList  nameVars = new ArrayList();
    static void ECHO(string stri1){
        string stri = "";
        if(stri1.Contains('"')){
            stri = stri1.Split('"')[1];
        }
        if(stri.Contains("$")){
            string alsd = stri.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = stri.Replace("$"+bltt,findVar(bltt));
            Console.WriteLine(fixStr);
        }else{
             Console.WriteLine(stri);
        }

    }
    static string findVar(string varName){
        string blayt = "";
        foreach (string item in nameVars)
        {
            
            string name = item.Split(":")[0];
            if(name == varName){
                blayt = item.Split(":")[1];

            }
        }
        return blayt;
    }
    public static void READMSG(string stri){
        if(stri.Contains("$")){
            string alsd = stri.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = stri.Replace("$"+bltt,findVar(bltt));
            Console.Write(fixStr);
        }else{
             Console.Write(stri);
        }
    }
    public static void parseCommand(string command, string[] args){
        switch (command)
        {
            case "WRITE":
                ECHO(args[1]);
                break;
            case "WRITEVAR":
                Console.WriteLine("Use of illigal function! update v0.3.2");
                break;
            case "STORE":
            string varName = args[1];
            string argsValue = args[2];
            string braV = argsValue.Split('"')[1];
            nameVars.Add(varName+":"+braV);
            
            break;
            case "LIST":
            Console.WriteLine(findVar(args[1]));
            break;
            case "READMSG":
                READMSG(args[1].Split('"')[1]);
                break;
            case "READLINE":
                string readM = Console.ReadLine();
                string stri = args[1];
                 if(stri.Contains("$")){
                    string alsd = stri.Split("$")[1];
                    string bltt = alsd.Split(" ")[0];
        
                    nameVars.Add(bltt+":"+readM);
                    
                    }else{
                         //Dismiss it.

                    }
                break;
            case "READFILE":
                string fileName = args[1];
               
                 if(fileName.Contains("$")){
            string alsd = fileName.Split("$")[1];
            string bltt = alsd.Split(" ")[0];

            string fixStr = fileName.Replace("$"+bltt,findVar(bltt));
            fileName = fixStr;
        }else{
            //ofc dismiss
        }
                string pipeVar = args[2];
                 if(pipeVar.Contains("$")){
            string alsd = pipeVar.Split("$")[1];
            string bltt = alsd.Split(" ")[0];
            string liser = File.ReadAllText(fileName);
            nameVars.Add(bltt+":"+liser);
            
        }else{
             //Dissmiss
        }
            break;
            case "IF":
                string condition = args[1];
                string opperator = args[2];
                string gotoOp = args[3];
                //Place holder

            break;
            default:
                Console.Error.WriteLine("Invalid Syntax.");
            break;
        
        }

    }
    public static void Main(String[] args){
        using (StreamReader read = new StreamReader(args[0])) {
         string line;
         while ((line = read.ReadLine()) != null) {
            if(line == "" || line == " "){

            }else{
                string Command = line.Split(" ")[0];
                string[] cArgs = WSplit(line.Split(Command)[1]);
                parseCommand(Command,cArgs);
            }
         }
      }
      static string[] WSplit(string input)
    {
        List<string> result = new List<string>();
        bool insideQuotes = false;
        int start = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '\"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (input[i] == ' ' && !insideQuotes)
            {
                // Split the substring if outside quotes and encountering a space
                result.Add(input.Substring(start, i - start));
                start = i + 1;
            }
        }

        // Add the last substring (or the whole string if no space is encountered at the end)
        result.Add(input.Substring(start));

        return result.ToArray();
    }  
    }
    
}