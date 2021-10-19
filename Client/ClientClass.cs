using System;

namespace Client
{
    public class ClientClass
    {
		public ClientClass()
		{

		}

		public string Output(string key)
		{
			Common.IData DataMarshal = (Common.IData)Activator.GetObject(
			typeof(Common.IData), "tcp://localhost:8001/DataMarshal.rem");

			if (key == "")
			{
				return "Error!";
			}
			else
			{
				Common.Data dMarshal = DataMarshal.Object(key);
				return dMarshal.ToString();
			}
		}
	}
}
