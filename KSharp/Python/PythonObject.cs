namespace CRial.Python
{
    public class PythonObject
    {
        internal string _name;

        internal PythonObject(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
