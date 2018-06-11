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
            DirectoryService ds = new DirectoryService();

            string command;

            while (ds.working)
            {
                command = Console.ReadLine();
                ds.Commands(command);
            }
        }
    }
}
