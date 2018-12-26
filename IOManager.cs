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
                a.korzen=a.WstawSlowo(a.korzen, substrings[i]);
				var ang = a.Wyszukaj(a.korzen, substrings[i]);
                p.korzen=p.WstawSlowo(p.korzen, substrings[i + 1]);
				var pl = p.Wyszukaj(p.korzen, substrings[i + 1]);
                ang.Tlumaczenie = pl;
                pl.Tlumaczenie = ang;
                Debug.WriteLine(pl.Tlumaczenie.Slowo);
                Debug.WriteLine(ang.Tlumaczenie.Slowo);
            }
        }
        public void WypiszSlowa(Wezel korzen)
        {
            if (!wrInitialised)
            {
                wr = new StreamWriter("InOut0401.txt");
                wrInitialised = true;
            }
            if (korzen == null)
                return;
            if (korzen.Tlumaczenie == null)
                Console.WriteLine("err: Brak tlumaczenia dla {0}", korzen.Slowo);
            else
                wr.WriteLine("{0} {1}", korzen.Slowo, korzen.Tlumaczenie.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszSlowa(korzen.Lewy);
            }
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
