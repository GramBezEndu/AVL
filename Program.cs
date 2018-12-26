using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        public static Random rnd = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmn";
            //const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            DrzewoPolskie p = new DrzewoPolskie();
            DrzewoAngielskie a = new DrzewoAngielskie();
            IOManager ioManager = new IOManager();
            ioManager.WczytajSlowa(a, p);
            string input;
            bool exit = false;
            while (true)
            {
                Console.WriteLine("1. Wstaw slowo polskie");
                Console.WriteLine("2. Wstaw slowo angielskie");
                Console.WriteLine("3. Wyszukaj slowo polskie");
                Console.WriteLine("4. Wyszukaj slowo angielskie");
                Console.WriteLine("5. Usun slowo polskie");
                Console.WriteLine("6. Usun slowo angielskie");
                Console.WriteLine("7. Wypisz slownik");
                Console.WriteLine("8. Dodaj 4 losowe słowa do słownika");
                Console.WriteLine("9. Usun 2 losowe slowa ze slownika");
                Console.WriteLine("0. Wyjdz i zapisz zmiany");
                input = Console.ReadLine();
                int d;
                if (!Int32.TryParse(input, out d))
                {
                    Console.WriteLine("Wybierz liczbe z przedzialu 0-6");
                    Console.ReadKey();
                }
                switch (d)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("Podaj slowo polskie");
                        input = Console.ReadLine();
						string oldInput = input;
                        Wezel temp = p.korzen;
                        try
                        {
                            temp = p.WstawSlowo(temp, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        p.korzen = temp;
						var pol = p.Wyszukaj(p.korzen, input);
                        Console.WriteLine("Podaj tlumaczenie");
                        input = Console.ReadLine();
                        Wezel temp2 = a.korzen;
                        try
                        {
                            temp2 = a.WstawSlowo(temp2, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
							//Usun wstawione slowo polskie, poniewaz nie mozna wstawic tlumaczenia
							temp = p.UsunSlowo(temp, oldInput);
							p.korzen = temp;
                            //throw new NotImplementedException();
                            break;
                        }
                        a.korzen = temp2;
                        var ang = a.Wyszukaj(a.korzen, input);
                        ang.Tlumaczenie = pol;
                        pol.Tlumaczenie = ang;
                        break;

                    case 2:
                        Console.WriteLine("Podaj slowo angielskie");
                        input = Console.ReadLine();
						string oldInput2 = input;
                        Wezel temp3 = a.korzen;
                        try
                        {
							temp3 = a.WstawSlowo(temp3, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        a.korzen = temp3;
                        var ang1 = a.Wyszukaj(a.korzen, input);
                        Console.WriteLine("Podaj tlumaczenie");
                        input = Console.ReadLine();
                        Wezel temp4 = p.korzen;
                        try
                        {
                            temp4 = p.WstawSlowo(temp4, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
							//Usun wstawione slowo angielskie, poniewaz nie mozna wstawic tlumaczenia
							temp3 = a.UsunSlowo(temp3, oldInput2);
							a.korzen = temp3;
                            //throw new NotImplementedException();
                            break;
                        }
                        p.korzen = temp4;
                        var pol1 = p.Wyszukaj(p.korzen, input);
                        ang1.Tlumaczenie = pol1;
                        pol1.Tlumaczenie = ang1;
                        break;

                    case 3:
                        Console.WriteLine("Podaj slowo angielskie");
                        input = Console.ReadLine();
                        var ang2 = a.Wyszukaj(a.korzen, input);
                        if (ang2 == null)
                        {
                            Console.WriteLine("Podane slowo angielskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (ang2.Tlumaczenie == null)
                            {
                                Console.WriteLine("Podane slowo nie ma tlumaczenia");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Tłumaczeniem: " + ang2.Slowo + " jest: " + ang2.Tlumaczenie.Slowo);
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Podaj slowo polskie");
                        input = Console.ReadLine();
                        var pol3 = p.Wyszukaj(p.korzen, input);
                        if (pol3 == null)
                        {
                            Console.WriteLine("Podane slowo polskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (pol3.Tlumaczenie == null)
                            {
                                Console.WriteLine("Podane slowo nie ma tlumaczenia");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Tłumaczeniem: " + pol3.Slowo + " jest: " + pol3.Tlumaczenie.Slowo);
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Podaj slowo polskie do usuniecia");
                        input = Console.ReadLine();
                        Wezel temp5 = p.korzen;
                        Wezel tlumaczenie = a.korzen;
						var szukane = p.Wyszukaj(p.korzen, input);
						var tlum = szukane.Tlumaczenie;
                        try
						{
                            temp5 = p.UsunSlowo(temp5, input);
                        }
                       catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        p.korzen=temp5;
						try
						{
							tlumaczenie = a.UsunSlowo(tlumaczenie, tlum.Slowo);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							break;
						}
						a.korzen = tlumaczenie;
                        break;
                    case 6:
                        Console.WriteLine("Podaj slowo angielskie do usuniecia");
                        input = Console.ReadLine();
                        Wezel temp6 = a.korzen;
                        Wezel tlumaczenie2 = p.korzen;
						var szukane2 = a.Wyszukaj(a.korzen, input);
						var tlum2 = szukane2.Tlumaczenie;
                        try
                        {
                            temp6 = a.UsunSlowo(temp6, input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        a.korzen = temp6;
						try
						{
							tlumaczenie2 = p.UsunSlowo(tlumaczenie2, input);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							break;
						}
						p.korzen = tlumaczenie2;
                        break;
                    case 7:
                        a.WypiszDrzewoOrazTlumaczenia(a.korzen);
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.Clear();
                        for(int i=0;i<4;i++)
                        {
                            string rndAng = RandomString(rnd.Next(1,4));
                            string rndPol = RandomString(rnd.Next(1,4));
                            Console.WriteLine("\tWstawienie slowa {0}", rndAng);
                            Wezel temp8 = a.korzen;
                            try
                            {
                                temp8 = a.WstawSlowo(temp8, rndAng);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                break;
                            }
                            a.korzen = temp8;
                            var tempAng = a.Wyszukaj(a.korzen, rndAng);
                            Wezel temp9 = p.korzen;
                            try
                            {
                                temp9 = p.WstawSlowo(temp9, rndPol);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
								//Usuwanie slowa pierwotnego -> nie mozna wstawic tlumaczenia
								temp8 = a.UsunSlowo(temp8, rndAng);
								a.korzen = temp8;
								break;
                            }
                            p.korzen = temp9;
                            var tempPol = p.Wyszukaj(p.korzen, rndPol);
                            tempAng.Tlumaczenie = tempPol;
                            tempPol.Tlumaczenie = tempAng;
                            a.WypiszDrzewoOrazTlumaczenia(a.korzen);
                            Console.WriteLine();
                        }
                        break;
                    case 9:
                        Console.Clear();
                        int deleted = 0;
                        while(deleted !=2)
                        {
                            string rnd1 = RandomString(rnd.Next(1,4));
                            Wezel temp1337 = a.korzen;
                            Wezel tlum3 = p.korzen;
                            //Console.WriteLine("\tProba usuniecia slowa {0}", rnd);
                            try
                            {
								var szukane3 = a.Wyszukaj(a.korzen, rnd1);
								var tl3 = szukane3.Tlumaczenie;
                                temp1337 = a.UsunSlowo(temp1337, rnd1);
								a.korzen = temp1337;

								tlum3 = p.UsunSlowo(tlum3, tl3.Slowo);
								p.korzen = tlum3;
								//Note: it will only print it if no exception was thrown -> it means only if word was found
								Console.WriteLine("\t\tUsunieto slowo {0}", rnd1);
                                deleted++;
                                a.WypiszDrzewoOrazTlumaczenia(a.korzen);
                                Console.WriteLine();
                            }
                            //Pomin brak slowa exception - bylo wylosowane
                            catch (Exception e)
                            {
                                //Console.WriteLine(e.Message);
                                //break;
                            }
                        }
                        break;
                }
                if (exit)
                    break;
            }
            Console.WriteLine("\nSlownik angielski:");
            a.WypiszDrzewo(a.korzen);
            Console.WriteLine("\nSlownik polski:");
            p.WypiszDrzewo(p.korzen);
            ioManager.WypiszSlowa(a.korzen);
            ioManager.closeStreamWriter();
            Console.ReadKey();

        }
    }
}
