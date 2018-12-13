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
        static void Main(string[] args)
        {
            DrzewoPolskie p = new DrzewoPolskie();
            DrzewoAngielskie a = new DrzewoAngielskie();
            IOManager ioManager = new IOManager();
            ioManager.WczytajSlowa(a, p);
            string input;
            Stopwatch watch;
            bool exit = false;
            while (true)
            {
                Console.WriteLine("1. Wstaw slowo polskie");
                Console.WriteLine("2. Wstaw slowo angielskie");
                Console.WriteLine("3. Wyszukaj slowo polskie");
                Console.WriteLine("4. Wyszukaj slowo angielskie");
                Console.WriteLine("5. Usun slowo polskie");
                Console.WriteLine("6. Usun slowo angielskie");
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
                        Wezel temp = p.korzen;
                        bool rotacja = false;
                        watch = Stopwatch.StartNew();
                        try
                        {

                            p.WstawSlowo(ref temp, input, ref rotacja);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        p.korzen = temp;
                        watch.Stop();
                        Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        var pol = p.Wyszukaj(p.korzen, input);
                        Console.WriteLine("Podaj tlumaczenie");
                        input = Console.ReadLine();
                        Wezel temp2 = a.korzen;
                        bool rotacja2 = false;
                        watch = Stopwatch.StartNew();
                        try
                        {
                            a.WstawSlowo(ref temp2, input, ref rotacja2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        a.korzen = temp2;
                        var ang = a.Wyszukaj(a.korzen, input);
                        ang.Tlumaczenie = pol;
                        pol.Tlumaczenie = ang;
                        break;

                    case 2:
                        Console.WriteLine("Podaj slowo angielskie");
                        input = Console.ReadLine();
                        Wezel temp3 = a.korzen;
                        bool rotacja3 = false;
                        watch = Stopwatch.StartNew();
                        try
                        {

                            a.WstawSlowo(ref temp3, input, ref rotacja3);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        a.korzen = temp3;
                        watch.Stop();
                        Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        var ang1 = a.Wyszukaj(a.korzen, input);
                        Console.WriteLine("Podaj tlumaczenie");
                        input = Console.ReadLine();
                        Wezel temp4 = p.korzen;
                        bool rotacja4 = false;
                        watch = Stopwatch.StartNew();
                        try
                        {
                            p.WstawSlowo(ref temp4, input, ref rotacja4);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Dodano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        p.korzen = temp4;
                        var pol1 = p.Wyszukaj(p.korzen, input);
                        ang1.Tlumaczenie = pol1;
                        pol1.Tlumaczenie = ang1;
                        break;

                    case 3:
                        Console.WriteLine("Podaj slowo angielskie");
                        input = Console.ReadLine();
                        watch = Stopwatch.StartNew();
                        var ang2 = a.Wyszukaj(a.korzen, input);
                        watch.Stop();
                        if (ang2 == null)
                        {
                            Console.WriteLine("Podane slowo angielskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wyszukano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
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
                        watch = Stopwatch.StartNew();
                        var pol3 = p.Wyszukaj(p.korzen, input);
                        watch.Stop();
                        if (pol3 == null)
                        {
                            Console.WriteLine("Podane slowo polskie nie istnieje");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wyszukano. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
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
                        bool znaleziony = false;
                        bool wywazone = false;
                        watch = Stopwatch.StartNew();
                        try{
                            p.UsunSlowo(ref temp5, input, ref znaleziony, ref wywazone, a.korzen);
                        }
                       catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Usunieto wybrany element. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        p.korzen=temp5;
                        break;
                    case 6:
                        Console.WriteLine("Podaj slowo angielskie do usuniecia");
                        input = Console.ReadLine();
                        Wezel temp6 = a.korzen;
                        bool znaleziony2 = false;
                        bool wywazone2 = false;
                        watch = Stopwatch.StartNew();
                        try
                        {
                            a.UsunSlowo(ref temp6, input, ref znaleziony2, ref wywazone2, p.korzen);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        watch.Stop();
                        Console.WriteLine("Usunieto wybrany element. Zajelo to: {0} milisekund", (double)watch.ElapsedMilliseconds);
                        a.korzen = temp6;
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
