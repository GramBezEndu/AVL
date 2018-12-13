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

        public Wezel WyszukajNastepce(ref Wezel korzen)
        {
            Wezel nastepca = korzen.Prawy;
            while(nastepca.Lewy!=null)
            {
                if (nastepca.Lewy.Slowo.CompareTo(korzen.Slowo) == 0) //przyda sie przy usuwaniu starej pozycji nastepnika
                    break;
                nastepca = nastepca.Lewy;
            }
            return nastepca;
        }

        public void UsunSlowo(ref Wezel korzen, string slowo,ref bool ZnalezionoElement, ref bool DrzewoWywazone)
        {

            //Wyszukaj powinno zwracac czy slowo nieistnieje

            if (korzen == null || slowo.CompareTo(korzen.Slowo) == 0)
            {

                ZnalezionoElement = true;
                if (korzen.Prawy == null && korzen.Lewy == null)
                {
                    //przypadek gdy usuwany element jest lisciem
                    korzen = null;
                    //NALEZY USUNAC TEZ TLUMACZENIE
                    //throw new NotImplementedException();
                }
                return;
            }
            // Key is greater than root's key   
            if (slowo.CompareTo(korzen.Slowo)< 0)
            {
                Wezel lewy = korzen.Lewy;
                bool element = ZnalezionoElement;
                bool wywazenie = DrzewoWywazone;
                UsunSlowo(ref lewy, slowo,ref element, ref wywazenie);
                DrzewoWywazone = wywazenie;
                ZnalezionoElement = element;
                if(!DrzewoWywazone)
                {

                    if (korzen.Lewy.Waga == -1 || korzen.Lewy.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                    else
                    {
                        korzen.Waga--;
                    }
                }
                    
            }
            if (ZnalezionoElement)
            {
                ZnalezionoElement = false;
                //Rozpatrujemy przypadek gdy element kasowany nie jest lisciem
                if(korzen.Lewy.Prawy==null && korzen.Lewy.Lewy!=null)
                {
                    Wezel temp = korzen.Lewy;
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    korzen.Lewy = temp.Lewy;
                }
                if (korzen.Lewy.Prawy != null && korzen.Lewy.Lewy == null)
                {
                    Wezel temp = korzen.Lewy;
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    korzen.Lewy = temp.Prawy;
                }
                if (korzen.Lewy.Prawy != null && korzen.Lewy.Lewy != null)
                {
                    Wezel temp = korzen.Lewy;
                    Wezel nastepnik = WyszukajNastepce(ref temp);
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    Wezel staraPozycjaNastepnika = nastepnik;
                    Wezel nastepniknastepnika = WyszukajNastepce(ref staraPozycjaNastepnika);
                    nastepniknastepnika.Lewy = null;
                    korzen.Lewy = nastepnik;

                }
            }
            //Key is smaller than root's key
            if (slowo.CompareTo(korzen.Slowo) > 0)
            {
                Wezel prawy = korzen.Prawy;
                bool element = ZnalezionoElement;
                bool wywazenie = DrzewoWywazone;
                UsunSlowo(ref prawy, slowo, ref element, ref wywazenie);
                DrzewoWywazone = wywazenie;
                ZnalezionoElement = element;
                if (!DrzewoWywazone)
                {

                    if (korzen.Lewy.Waga == -1 || korzen.Lewy.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                    else
                    {
                        korzen.Waga++;
                    }
                }
            }
            //Usuwanie znalezionego elementu
            if (ZnalezionoElement)
            {
                ZnalezionoElement = false;
                //Rozpatrujemy przypadek gdy element kasowany nie jest lisciem
                if (korzen.Prawy.Prawy == null && korzen.Prawy.Lewy != null)
                {
                    Wezel temp = korzen.Prawy;
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    korzen.Prawy = temp.Lewy;
                }
                if (korzen.Prawy.Prawy != null && korzen.Prawy.Lewy == null)
                {
                    Wezel temp = korzen.Prawy;
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    korzen.Prawy = temp.Prawy;
                }
                if (korzen.Prawy.Prawy != null && korzen.Prawy.Lewy != null)
                {
                    Wezel temp = korzen.Prawy;
                    Wezel nastepnik = WyszukajNastepce(ref temp);
                    ////NALEZY USUNAC TEZ TLUMACZENIE
                    throw new NotImplementedException();
                    korzen.Prawy.Slowo = nastepnik.Slowo;
                    //UsunSlowo();
                    /*Wezel staraPozycjaNastepnika = nastepnik;

                    Wezel nastepniknastepnika = WyszukajNastepce(ref staraPozycjaNastepnika);
                    nastepniknastepnika.Lewy = null;
                    korzen.Prawy = nastepnik;*/
                    
                }
            }
            //Rotacje (trzeba zrobić z tego oddzielną funkcje IMHO)
            if (korzen.Waga == 2)
            {
                if (korzen.Lewy.Waga == 1)
                {
                    Wezel wezel = korzen;
                    RotacjaRR(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    korzen.Waga = 0;
                    korzen.Prawy.Waga = 0;
                }
                else
                {
                    Wezel C = korzen.Lewy.Prawy;
                    Wezel wezel = korzen.Lewy;
                    RotacjaLL(ref wezel);
                    korzen.Lewy = wezel;
                    wezel = korzen;
                    RotacjaRR(ref wezel);
                    korzen= wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = -1;
                            break;
                        case (0):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = 0;
                            break;
                        case (-1):
                            korzen.Prawy.Waga = 1;
                            korzen.Lewy.Waga = 0;
                            break;

                    }
                    korzen.Waga = 0;
                }
            }
            if (korzen.Waga == -2)
            {

                if (korzen.Prawy.Waga == 1)
                {
                    Wezel C = korzen.Prawy.Lewy;
                    Wezel wezel = korzen.Prawy;
                    RotacjaRR(ref wezel);
                    korzen.Prawy = wezel;
                    wezel = korzen;
                    RotacjaLL(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = -1;
                            break;
                        case (0):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = 0;
                            break;
                        case (-1):
                            korzen.Prawy.Waga = 1;
                            korzen.Lewy.Waga = 0;
                            break;

                    }
                    korzen.Waga = 0;

                }
                else
                {
                    Wezel wezel = korzen;
                    RotacjaLL(ref wezel);
                    //root = (WezelPolski)wezel;
                    korzen = wezel;
                    //ustawianie nowych wag
                    korzen.Waga = 0;
                    korzen.Lewy.Waga = 0;
                }
            }



        }

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
                if (CzyBylaRotacja == true && root.Lewy.Waga == 0) //We wstawianiu rotacja wykona sie tylko raz
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
                if (CzyBylaRotacja == true && root.Prawy.Waga==0) //We wstawianiu rotacja wykona sie tylko raz
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
							root.Prawy.Waga = 1;
							root.Lewy.Waga = 0;
							break;

					}
                    root.Waga = 0;
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
                            root.Prawy.Waga = 1;
                            root.Lewy.Waga = 0;
                            break;

                    }
                    root.Waga = 0;

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
