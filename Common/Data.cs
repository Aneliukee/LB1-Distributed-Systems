using System;
using System.Threading;

namespace Common
{
    [Serializable]
    public class Data
    {
        private string _name, _email, _number;

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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public Data()
        {

        }

        public override string ToString()
        {
            string line = string.Format("{0, -10}, {1, -10}, {2, -10}", Name, Email, Number);
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
