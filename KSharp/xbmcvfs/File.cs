using CRial.Python;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRial.xbmcvfs
{
    public enum SeekOriginPosition : int
    {

    }
    public class File : PythonObject
    {
        public File(string name) : base(name)
        {
            _name = name;
        }

        public File(string filepath, FileAccess mode) : base("")
        {
            _name = "self.f_" + Utils.GenerateId();
            if(mode == FileAccess.Read)Utils.Call(_name + " = xbmcvfs.File('"+filepath+"')");
            else Utils.Call(_name + " = xbmcvfs.File('" + filepath + "', 'w')");
        }
        public void Close()
        {
            Utils.Call(_name + ".close()");
        }
        public string Read(int numBytes= 0)
        {
            return Utils.Call<string>(_name + ".read("+numBytes+")");
        }
        public long Seek(long seekBytes, SeekOrigin iWhence)
        {
           return Utils.Call<long>(_name + ".seek(" + seekBytes + ", "+(int)iWhence+")");
        }
        public long Size()
        {
            return Utils.Call<long>(_name + ".size()");
        }
        public bool write(string buffername)
        {
            return Utils.Call<bool>(_name + ".write("+buffername+")");
        }
    }
}
