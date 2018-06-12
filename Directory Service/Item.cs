using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory_Service
{
    interface Item
    {
        string SimpleFormat();
        string ComplexFormat();
        void AddAttribute(string key, string val);
    }
}
