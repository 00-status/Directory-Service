using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Directory Service object. This object manages the entire program.
            DirectoryService ds = new DirectoryService();

            // A string that holds each command the user enters.
            string command;

            // Loop until the user enters a command to exit the program
            while (ds.working)
            {
                // Take in a command from the user.
                command = Console.ReadLine();
                // Send the command to the Directory Service
                ds.Commands(command);
            }
        }
    }
}
