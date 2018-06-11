using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Service
{
    class Artifact : Item
    {
        private int id;
        Dictionary<string,string> attributes = new Dictionary<string, string>();

        public Artifact(int id)
        {
            this.id = id;
        }

        public void AddAttribute(string key, string val)
        {
            attributes[key] = val;
            Console.WriteLine( attributes.First().Value );
        }

        public string SimpleFormat()
        {
            // Get the first attribute's value
            KeyValuePair<string,string> keyval = attributes.First();
            return id + " | " +keyval.Value;
        }
    }
}
