using System;
using System.Collections.Generic;
using list;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
class Program
{
    public static void Main()
    {
        List<Person> MainList = new List<Person>();

        FileWork file = new FileWork();
        MainList = file.ReadToList();
        CommandWorker worker = new CommandWorker(MainList, file);
        worker.Help();

        while (worker.work == true)
        {          
            string input1 = Console.ReadLine();
            worker.CommandExcecute(input1);
        }
    }
}


