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

		public void RotacjaRR(ref Wezel element)
		{
			//zmiana pozycji
			Wezel A = element;
			element = A.Lewy;
			Wezel II = element.Prawy;
			element.Prawy = A;
			element.Prawy.Lewy = II;
		}

/*		public Wezel WstawSlowo(ref Wezel root, string slowo)
		{
			//int comparison = slowo.CompareTo(root.Slowo);
			if (root == null)
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
				if (true) //MUSI JAKOS SPRAWDZAC CZY WYKONALA SIE REKURENCJA CZY NIE
				{
					root.Waga--;
				}

			}
			else
			{
				throw new Exception("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
			}
			if (root.Waga == 2)
			{
				if (root.Lewy.Waga == 1)
				{
					Wezel wezel = root;
					RotacjaRR(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					root.Prawy.Waga = 0;
				}
				else
				{
					Wezel C = root.Lewy.Prawy;
					Wezel wezel = root.Lewy;
					RotacjaLL(ref wezel);
					root.Lewy = wezel;
					wezel = root;
					RotacjaRR(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					switch (C.Waga)
					{
						case (1):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = -1;
							break;
						case (0):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = 0;
							break;
						case (-1):
							root.Prawy.Waga = 0;
							root.Lewy.Waga = 1;
							break;

					}
				}
			}
			if (root.Waga == -2)
			{

				if (root.Prawy.Waga == 1)
				{
					Wezel C = root.Prawy.Lewy;
					Wezel wezel = root.Prawy;
					RotacjaRR(ref wezel);
					root.Prawy = wezel;
					wezel = root;
					RotacjaLL(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					switch (C.Waga)
					{
						case (1):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = -1;
							break;
						case (0):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = 0;
							break;
						case (-1):
							root.Prawy.Waga = 0;
							root.Lewy.Waga = 1;
							break;

					}

				}
				else
				{
					Wezel wezel = root;
					RotacjaLL(ref wezel);
					//root = (WezelPolski)wezel;
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					root.Lewy.Waga = 0;
				}
			}
			Debug.WriteLine("\t\t{0}", slowo);
			Debug.WriteLine("\t\t{0}", root.Slowo);
			return root;
		}*/

		public void WypiszDrzewo(Wezel korzen)
        {
            Console.WriteLine(korzen.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszDrzewo(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            if (korzen.Prawy != null)
            {
                WypiszDrzewo(korzen.Prawy);
            }
        }
		public Wezel Wyszukaj(Wezel korzen, string slowo)
		{
			// Base Cases: root is null or key is present at root 	
			if (korzen == null || slowo.CompareTo(korzen.Slowo) == 0)
				return korzen;
			//return null;	
			// Key is greater than root's key 	
			if (korzen.Slowo.CompareTo(slowo) < 0)
				return Wyszukaj(korzen.Prawy, slowo);
			//Key is smaller than root's key 	
			return Wyszukaj(korzen.Lewy, slowo);
		}

		//public Wezel WstawSlowo(ref Wezel root, string slowo)
		//{
		//    //int comparison = slowo.CompareTo(root.Slowo);
		//    if(root == null)
		//    {
		//        root = new Wezel(slowo);
		//    }
		//    //if (this.korzen == null) //gdy drzewo jeszcze nie jest utworzone
		//    //{
		//    //    this.korzen = new Wezel(slowo);
		//    //}
		//    else if (slowo.CompareTo(root.Slowo) < 0)
		//    {
		//        Wezel lewy = root.Lewy;
		//        root.Lewy = WstawSlowo(ref lewy, slowo);
		//        root.Waga++;
		//    }
		//    else if (slowo.CompareTo(root.Slowo) > 0)
		//    {
		//        Wezel prawy = root.Prawy;
		//        root.Prawy = WstawSlowo(ref prawy, slowo);
		//        root.Waga--;
		//    }
		//    else
		//    {
		//        throw new Exception("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
		//    }
		//    //sprawdzanie wag
		//    if (root.Waga == 0)
		//        return root;
		//    if (root.Waga >= 2)
		//    {
		//        if (root.Lewy.Waga == 1)
		//            RotacjaRR(ref root);
		//        else
		//            RotacjaLR(ref root);
		//    }
		//    if (root.Waga <= -2)
		//    {

		//        if (root.Prawy.Waga == 1)
		//            RotacjaRL(ref root);
		//        else
		//            RotacjaLL(ref root);
		//    }
		//    Debug.WriteLine("\t\t{0}", slowo);
		//    Debug.WriteLine("\t\t{0}", root.Slowo);
		//    return root;
		//}
		public Wezel WstawSlowo(ref Wezel root, string slowo, ref bool CzyBylaRotacja)
		{
			if (root == null)
			{
				root = new Wezel(slowo);
			}
			else if (slowo.CompareTo(root.Slowo) < 0)
			{
				Wezel lewy = root.Lewy;
				bool rotacja = CzyBylaRotacja;
				root.Lewy = WstawSlowo(ref lewy, slowo, ref rotacja);
				CzyBylaRotacja = rotacja;
                if (CzyBylaRotacja == true || root.Lewy.Waga == 0) //We wstawianiu rotacja wykona sie tylko raz
                {

                }
                else
                {
                    root.Waga++;
                }
            }
			else if (slowo.CompareTo(root.Slowo) > 0)
			{
				Wezel prawy = root.Prawy;
				bool rotacja = CzyBylaRotacja;
				root.Prawy = WstawSlowo(ref prawy, slowo, ref rotacja);
				CzyBylaRotacja = rotacja;
                if (CzyBylaRotacja == true || root.Prawy.Waga==0) //We wstawianiu rotacja wykona sie tylko raz
				{
				
				}
                else
                {
                    root.Waga--;
                }

			}
			else
			{
				throw new Exception("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
			}
			if (CzyBylaRotacja)
			{
				return root;
			}
			if (root.Waga == 2)
			{
				if (root.Lewy.Waga == 1)
				{
					Wezel wezel = root;
					CzyBylaRotacja = true;
					RotacjaRR(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					root.Prawy.Waga = 0;
				}
				else
				{
					Wezel C = root.Lewy.Prawy;
					Wezel wezel = root.Lewy;
					CzyBylaRotacja = true;
					RotacjaLL(ref wezel);
					root.Lewy = wezel;
					wezel = root;
					RotacjaRR(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					switch (C.Waga)
					{
						case (1):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = -1;
							break;
						case (0):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = 0;
							break;
						case (-1):
							root.Prawy.Waga = 0;
							root.Lewy.Waga = 1;
							break;

					}
				}
			}
			if (root.Waga == -2)
			{

				if (root.Prawy.Waga == 1)
				{
					Wezel C = root.Prawy.Lewy;
					Wezel wezel = root.Prawy;
					CzyBylaRotacja = true;
					RotacjaRR(ref wezel);
					root.Prawy = wezel;
					wezel = root;
					RotacjaLL(ref wezel);
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					switch (C.Waga)
					{
						case (1):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = -1;
							break;
						case (0):

							root.Prawy.Waga = 0;
							root.Lewy.Waga = 0;
							break;
						case (-1):
							root.Prawy.Waga = 0;
							root.Lewy.Waga = 1;
							break;

					}

				}
				else
				{
					Wezel wezel = root;
					CzyBylaRotacja = true;
					RotacjaLL(ref wezel);
					//root = (WezelPolski)wezel;
					root = wezel;
					//ustawianie nowych wag
					root.Waga = 0;
					root.Lewy.Waga = 0;
				}
			}
			Debug.WriteLine("\t\t{0}", slowo);
			Debug.WriteLine("\t\t{0}", root.Slowo);
			return root;
		}
	}
}
