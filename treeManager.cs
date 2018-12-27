using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class treeManager
    {
        DrzewoPolskie p;
        DrzewoAngielskie a;
        public void WstawSlowo(string polskie, string angielskie, DrzewoPolskie p, DrzewoAngielskie a)
        {
            bool Rotacja = false;
            var pl = p.WstawSlowo(ref p.korzen, polskie, ref Rotacja);
            var ang = a.WstawSlowo(ref a.korzen, angielskie, ref Rotacja);
            pl.Tlumaczenie = ang;
            ang.Tlumaczenie = pl;
        }
    }
}
