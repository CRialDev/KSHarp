using CRial.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcrpc
{
    public class Resume : PythonObject
    {
        internal Resume(string name) : base(name)
        {
            _name = name;
        }
        public Resume() : base("") { }
        public float Position;
        public float Total;
    }
}
