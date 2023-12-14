using System;
using System.Collections;
using System.Collections.Generic;

public class Program{
    static ArrayList  nameVars = new ArrayList();
    static void ECHO(string stri){
        
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
    public static void parseCommand(string command, string[] args){
        switch (command)
        {
            case "WRITE":
                ECHO(args[1].Split('"')[1]);
                break;
            case "STORE":
            string varName = args[1];
            string argsValue = args[2];
            nameVars.Add(varName+":"+argsValue);
            
            break;
            case "LIST":
            Console.WriteLine(findVar(args[1]));
            break;
            default:

            break;
        }
    }
    public static void Main(String[] args){
        using (StreamReader read = new StreamReader(args[0])) {
         string line;
         while ((line = read.ReadLine()) != null) {
            string Command = line.Split(" ")[0];
            string[] cArgs = WSplit(line.Split(Command)[1]);
            parseCommand(Command,cArgs);
          
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