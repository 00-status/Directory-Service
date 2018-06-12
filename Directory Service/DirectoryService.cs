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
        // A variable that keeps track of how many items are in the system
        public int currentId = 1;

        // A list of all items in the system
        private Dictionary<int, Item> items = new Dictionary<int,Item>();



        // Constants
        private const string HELP = "\n\nls: lists all items in the system. \n\tls\n\tls <id>" +
            "\nnew -<name>: adds an artifact with the given name." +
            "\nadd: adds an attribute to the given item. \n\tadd <id> <name> <value>" +
            "\ndel: removes an item from the system. \n\tdel <id>" +
            "\nclear: clears the console window. " +
            "\nexit: exits the program. ";



        public DirectoryService()
        {
            working = true;
            Console.WriteLine("Welcome to the Item Directory Service.\nType help for a list of commands");
        }

        public void Commands(string command)
        {
            command = command.Trim();
            // split the command into its elements
            List<string> commandBits = new List<string>(command.Split(' '));

            // Get the actual command from the split string
            string prefix = commandBits[0];
            // Convert the prefix to lowercase
            prefix = prefix.ToLower();
            // Trim any extra whitespace off
            prefix = prefix.Trim();
            if (prefix == "help" )
            {
                // Displays help text
                Console.WriteLine(HELP);
            }
            else if (prefix == "ls")
            {
                // Check if the command has a parameter
                if (2 > commandBits.Count)
                {
                    // If there is not a second parameter, then call the listItems function
                    // ListItems loops through all items and displays them in a simple format
                    listItems();
                }
                else
                {
                    // If there is a second parameter, then call listComplex
                    ListComplex(commandBits[1]);
                }
            }
            else if (prefix == "new")
            {
                // Create a new artifact with the given name
                CreateArtifact(commandBits[1]);
            }
            else if (prefix == "add")
            {
                // Check if three parameters were specified
                if (4 > commandBits.Count)
                {
                    Console.WriteLine("This command requires 3 parameters.\nadd <id> <name> <value>");
                }
                else
                {
                    addToArtifact(commandBits[1], commandBits[2], commandBits[3]);
                }
            }
            else if (prefix == "del")
            {
                // Check if an id was specified
                if (2 > commandBits.Count)
                {
                    Console.WriteLine("This command requires a parameter.\ndel <id>");
                }
                else
                {
                    DeleteItem(commandBits[1]);
                }
            }
            else if (prefix == "clear")
            {
                // Clear the console
                Console.Clear();
            }
            else if (prefix == "exit")
            {
                // Set working to false. This will allow the program to finish
                working = false;
            }
        }

        private void addToArtifact(string id, string name, string value)
        {
            // Convert the id to a int
            int result = 0;
            Int32.TryParse(id, out result);

            Item holder = null;
            // Get the specified item
            if (items.TryGetValue(result, out holder))
            {
                // Add the attribute to the artifact
                holder.AddAttribute(name, value);
                Console.WriteLine(name + ": "  + value + " added to item.");
            }
            else
            {
                Console.WriteLine("The specified item couldn't be found");
            }
        }

        private void ListComplex(string id)
        {
            // Convert the id to a int
            int result = 0;
            Int32.TryParse(id, out result);

            Item holder = null;
            // Get the specified item
            if (items.TryGetValue(result, out holder))
            {
                // List the attributes of the given item
                Console.WriteLine(holder.ComplexFormat());
            }
            else
            {
                Console.WriteLine("The specified item couldn't be found");
            }
        }

        private void DeleteItem(string id)
        {
            // Convert the id to a int
            int result = 0;
            Int32.TryParse(id, out result);

            // Index into the dictionary and find the id
            if ( items.Remove(result) )
            {
                Console.WriteLine("Item successfully removed!");
            }
            else
            {
                Console.WriteLine("No such item exists.");
            }
        }

        private void CreateArtifact(string name)
        {
            // Create an empty artifact
            Artifact newItem = new Artifact(currentId);

            // fill in the name attribute
            newItem.AddAttribute("name", name);

            // Add the new item to the dictionary
            items[currentId] = newItem;
            // Increment the currentId
            currentId++;
            Console.WriteLine("Item: " + name + " created");
        }

        private void listItems()
        {
            // Loop through each item in the dictionary and print out the simple format for it.
            foreach (var item in items)
            {
                Console.WriteLine( item.Value.SimpleFormat() );
            }
        }
    }
}
