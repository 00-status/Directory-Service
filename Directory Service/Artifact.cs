using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Service
{
    class Artifact : Item
    {
        // The given id for this Artifact
        private int id;
        // A dictionary that holds the an attribute (or field) name and value.
        Dictionary<string,string> attributes = new Dictionary<string, string>();

        // A constructor that sets the given id for this artifact
        public Artifact(int id)
        {
            this.id = id;
        }

        public void AddAttribute(string[] attributeNames, string[] attributeFields)
        {
            for (int i = 0; i < attributeNames.Length; i++)
            {
                attributes[attributeNames[i]] = attributeFields[i];
            }
        }
        // A method that will add an attribute to the artifact's dictionary
        public void AddAttribute(string key, string val)
        {
            attributes[key] = val;
        }

        public string SimpleFormat()
        {
            // Get the first attribute's value
            KeyValuePair<string,string> keyval = attributes.First();
            // Return the first attribute's value with the id
            return id + " | " +keyval.Value;
        }

        /// <summary>
        /// A function that displays all attributes of an artifact.
        /// </summary>
        /// <returns></returns>
        public string ComplexFormat()
        {
            // Display the id for this artifact
            string result = "ID: \t" + id + "\n";
            // Display all attributes associated with this artifact
            foreach (var keyval in attributes)
            {
                // Display the attribute name and value
                result += keyval.Key + ":\t" + keyval.Value + "\n";
            }

            // Return the resulting string
            return result;
        }
    }
}
