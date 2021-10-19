using System;
using Common;
using System.IO;
using System.Collections;

namespace Server
{
    class Base
    {
        const int Cn = 200;
        public Data[] Datas;
        public int n;

        public Base()
        {
            n = 0;
            Datas = new Data[Cn];
        }

        public Data Get(int i) { return Datas[i]; }
        public int GetCount() { return n; }
        public void Add(Data dt) { Datas[n++] = dt; }
    }

    public class Datas : MarshalByRefObject, IData
    {
        public Datas()
        {

        }

        Data IData.Object(string name)
        {
            const string file = "data1.txt";
            Base D1 = new Base();
            Read(ref D1, file);

            Hashtable Base1 = new Hashtable();
            for (int i = 0; i < D1.GetCount(); i++)
            {
                Base1.Add(D1.Get(i).Name, D1.Get(i));
            }

            Data d = new Data();

            if (Base1.Contains(name))
            {
                d.Name = Base1[name].ToString().Split(';')[0];
                d.Email = Base1[name].ToString().Split(';')[1];
                d.Number = Base1[name].ToString().Split(';')[2];
                Console.WriteLine("\nPerson is in 1st server!");
            }
            else
            {
                d.Name = "";
                d.Email = "";
                d.Number = "";
                Console.WriteLine("\nPerson not found!");
            }

            return d;
        }

        static void Read(ref Base D1, string fv)
        {
            string name, email, number;
            int n;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    name = parts[0];
                    email = parts[1];
                    number = parts[2];
                    Data dat = new Data
                    {
                        Name = name,
                        Email = email,
                        Number = number
                    };
                    D1.Add(dat);
                }
            }
        }
    }
}


