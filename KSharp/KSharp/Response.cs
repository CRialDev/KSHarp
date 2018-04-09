using System.Threading;

namespace CRial
{
    internal class Response
    {
        public AutoResetEvent AEvent = new AutoResetEvent(false);
        public string Value;
    }
}
