using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Service
{
    class DirectoryService
    {
        public bool working;
        public int currentId = 0;

        private List<Item> items = new List<Item>();



        // Constants
        private const string HELP = "Type ls to list all items in the system.";

        public DirectoryService()
        {
            working = true;
            Console.WriteLine("Welcome to the Item Directory Service.\n Type help for a list of commands");
        }

        public void Commands(string command)
        {
            // split the command into its elements
            List<string> commandBits = new List<string>(command.Split('-'));

            string prefix = commandBits[0];
            prefix = prefix.Trim();
            if (prefix == "help" )
            {
                Console.WriteLine(HELP);
            }
            else if (prefix == "ls")
            {
                listItems();
            }
            else if (prefix == "new")
            {
                CreateArtifact(commandBits[1]);
            }
        }

        private void CreateArtifact(string name)
        {
            // Create an empty artifact
            Artifact newItem = new Artifact(currentId);
            currentId++;

            // fill in the name attribute
            newItem.AddAttribute("name", name);

            items.Add(newItem);
            Console.WriteLine("Item: " + name + " created");
        }

        private void listItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine( item.SimpleFormat() );
            }
        }
    }
}
