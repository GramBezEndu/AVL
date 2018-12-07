using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AVL
{
    class Drzewo
    {
        public Wezel korzen;

        public void RotacjaLL(ref Wezel element)
        {
            //zmiana pozycji
            Wezel A = element;
            element = A.Prawy;
            Wezel II = element.Lewy;
            element.Lewy = A;
            element.Lewy.Prawy = II;
        }

        public void RotacjaRL(ref Wezel element)
        {
            throw new NotImplementedException();
        }

        public void RotacjaLR(ref Wezel element)
        {
            throw new NotImplementedException();
        }

        public void RotacjaRR(ref Wezel element)
        {
            //zmiana pozycji
            Wezel A = element;
            element = A.Lewy;
            Wezel II = element.Prawy;
            element.Prawy = A;
            element.Prawy.Lewy = II;
        }

        public Wezel WstawSlowo(ref Wezel root, string slowo)
        {
            //int comparison = slowo.CompareTo(root.Slowo);
            if(root == null)
            {
                root = new Wezel(slowo);
            }
            //if (this.korzen == null) //gdy drzewo jeszcze nie jest utworzone
            //{
            //    this.korzen = new Wezel(slowo);
            //}
            else if (slowo.CompareTo(root.Slowo) < 0)
            {
                Wezel lewy = root.Lewy;
                root.Lewy = WstawSlowo(ref lewy, slowo);
                root.Waga++;
            }
            else if (slowo.CompareTo(root.Slowo) > 0)
            {
                Wezel prawy = root.Prawy;
                root.Prawy = WstawSlowo(ref prawy, slowo);
                root.Waga--;
            }
            else
            {
                throw new Exception("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
            }
            //sprawdzanie wag
            if (root.Waga == 0)
                return root;
            if (root.Waga >= 2)
            {
                if (root.Lewy.Waga == 1)
                    RotacjaRR(ref root);
                else
                    RotacjaLR(ref root);
            }
            if (root.Waga <= -2)
            {

                if (root.Prawy.Waga == 1)
                    RotacjaRL(ref root);
                else
                    RotacjaLL(ref root);
            }
            Debug.WriteLine("\t\t{0}", slowo);
            Debug.WriteLine("\t\t{0}", root.Slowo);
            return root;
        }

        public void WypiszDrzewo(Wezel korzen)
        {
            if (korzen.Lewy != null)
            {
                WypiszDrzewo(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            Console.WriteLine(korzen.Slowo);
            if (korzen.Prawy != null)
            {
                WypiszDrzewo(korzen.Prawy);
            }
        }
    }
}
