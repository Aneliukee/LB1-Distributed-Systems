using System;
using System.Threading;

namespace Common
{
    public class Data
    {
        private string _id, _name;

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Data()
        {

        }

        public override string ToString()
        {
            string line = string.Format("{0, -10}, {1, -10}", ID, Name);
            return line;
        }

        public void Sleep()
        {
            try
            {
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException e)
            {
                throw e;
            }
        }
    }
}
