using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            DrzewoPolskie p = new DrzewoPolskie();
            DrzewoAngielskie a = new DrzewoAngielskie();
            IOManager ioManager = new IOManager();
            ioManager.WczytajSlowa(a,p);
            a.WypiszDrzewo(a.korzen);
            p.WypiszDrzewo(p.korzen);
            ioManager.WypiszSlowa(a.korzen);
            ioManager.closeStreamWriter();
            Console.ReadKey();
            //ioManager.WypiszSlowa(a,p);
        }
    }
}
