using System;
using Common;

namespace MasterServer
{
    public class DataM : MarshalByRefObject, IData
    {

        public DataM()
        {

        }

        Data IData.Object(string id)
        {
            Common.IData dataServer1;
            dataServer1 = (Common.IData)Activator.GetObject(
                typeof(Common.IData),
                "tcp://localhost:8002/Base.rem"
                );

            Common.IData dataServer2;
            dataServer2 = (Common.IData)Activator.GetObject(
                typeof(Common.IData),
                "tcp://localhost:8003/Base2.rem"
                );

            Common.IData dataServer3;
            dataServer3 = (Common.IData)Activator.GetObject(
                typeof(Common.IData),
                "tcp://localhost:8004/Base3.rem"
                );
            try
            {

                Data data1 = dataServer1.Object(id);
                Data data2 = dataServer2.Object(id);
                Data data3 = dataServer3.Object(id);
                if (data1.ID != null)
                {
                    Console.WriteLine("\nIn 1st server!");
                    return data1;
                }
                else if (data2.ID != null)
                {
                    Console.WriteLine("\nIn 2nd server!");
                    return data2;
                }
                else if (data3.ID != null)
                {
                    Console.WriteLine("\nIn 3rd server!");
                    return data3;
                }
                else
                {
                    Console.WriteLine("\nNot in this server!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in client: {0}", ex.Message);
                return null;
            }
        }

    }
}
