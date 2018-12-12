using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AVL
{
    class IOManager
    {
        StreamReader sr;
        StreamWriter wr;
        bool wrInitialised = false;
        public void WczytajSlowa(DrzewoAngielskie a, DrzewoPolskie p)
        {
            sr = new StreamReader("InOut0401.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            string[] substrings = s.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<substrings.Count();i+=2)
            {
                Debug.WriteLine("\t i={0}, substrings[i]={1}", i, substrings[i]);
                var ang = a.WstawSlowo(ref a.korzen, substrings[i]);
                var pl = p.WstawSlowo(ref p.korzen, substrings[i + 1]);
                ang.Tlumaczenie = pl;
                pl.Tlumaczenie = ang;
                Debug.WriteLine(pl.Tlumaczenie.Slowo);
                Debug.WriteLine(ang.Tlumaczenie.Slowo);
                ////parzyste - angielskie
                //if(i%2==0)
                //{
                //    a.WstawSlowo(ref a.korzen, substrings[i]);
                //    //a.Wstaw(new WezelPolski(substrings[i]));
                //}
                ////polskie
                //else
                //{
                //    p.WstawSlowo(ref p.korzen, substrings[i]);
                //}
            }
        }
        public void WypiszSlowa(Wezel korzen)
        {
            if (!wrInitialised)
            {
                wr = new StreamWriter("InOut0401.txt");
                wrInitialised = true;
            }
            if (korzen.Tlumaczenie == null)
                Console.WriteLine("Brak tlumaczenia dla {0}, nie zostało ono wypisane w pliku wyjsciowym", korzen.Slowo);
            else
                wr.WriteLine("{0} {1}", korzen.Slowo, korzen.Tlumaczenie.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszSlowa(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            //if (korzen.Tlumaczenie == null)
            //    throw new Exception("Brak tlumaczenia");
            //else
            if (korzen.Prawy != null)
            {
                WypiszSlowa(korzen.Prawy);
            }
        }
        public void closeStreamWriter()
        {
            if(wr != null)
            {
                this.wr.Close();
                wrInitialised = false;
            }
        }
    }
}
