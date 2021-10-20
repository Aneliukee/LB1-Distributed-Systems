using System;
using Common;
using System.IO;
using System.Collections;

namespace Server2
{
    class Base
    {
        const int Cn = 200;
        public Data[] Datas2;
        public int n;

        public Base()
        {
            n = 0;
            Datas2 = new Data[Cn];
        }

        public Data Get(int i) { return Datas2[i]; } 
        public int GetCount() { return n; }         
        public void Add(Data dt) { Datas2[n++] = dt; }
    }

    public class Datas2 : MarshalByRefObject, IData
    {
        public Datas2()
        {

        }

        Data IData.Object(string id)
        {
            const string file = "data2.txt";
            Base D1 = new Base();
            Read(ref D1, file);

            Hashtable Base1 = new Hashtable();
            for (int i = 0; i < D1.GetCount(); i++)
            {
                Base1.Add(D1.Get(i).Name, D1.Get(i));
            }

            Data d = new Data();

            if (Base1.ContainsKey(id))
            {
                d.ID = id;
                d.Name = Base1[id].ToString().Split(';')[1];
                Console.WriteLine("\nPerson is in 2nd server!");
            }
            else
            {
                d.ID = "";
                d.Name = "";
                Console.WriteLine("\nPerson not found!");
            }

            return d;
        }

        static void Read(ref Base D1, string fv)
        {
            string name, id;
            int n;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    id = parts[0];
                    name = parts[1];
                    Data dat = new Data
                    {
                        ID = id,
                        Name = name,
                    };
                    D1.Add(dat);
                }
            }
        }
    }

}


