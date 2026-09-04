using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        class Lis { public List<Data> Lista = new(); }
        class Data
        {
            public int ID { get; set; }
            public int Cena { get; set; }
            public string Nazwa { get; set; }
        }

        static Lis l = new Lis(); // Przechowywanie listy jako pole statyczne

        //CLI
        static void Main(string[] args)
        {
            Console.WriteLine("Wytamya w kalkulatorze wydatków domowych.");
            while (true)
            {
                Console.WriteLine(@"Proszę wybrać jedną z opcji.
1. Dodawanie wydatków.
2. Wyświetlanie listy wszystkich wydatków.
3. Obliczanie łącznej kwoty wydatków.
4. Znalezienie wydatku o najwyższej wartości.
5. Wyjście z programu.");

                string odp = Console.ReadLine();
                if (Int32.TryParse(odp, out int odpowiedz)) //Sprawdza czy użytkownik podał liczbe a nie inny znak.
                {
                    if (odpowiedz == 1)
                    {
                        dod();
                    }
                    else if (odpowiedz == 2)
                    {
                        wys();
                    }
                    else if (odpowiedz == 3)
                    {
                        obl();
                    }
                    else if (odpowiedz == 4)
                    {
                        najw();
                    }
                    else if (odpowiedz == 5)
                    {
                        Console.WriteLine("Dziękujemy za korzystanie z programu. \nProszę nacisnąć ENTER aby kontynuować.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podano odpowiedź nie poprawną. \nProszę wybrać jedną z dostępnych opcji. \nProsze nacisnąć ENTER aby kontynuować");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Podano odpowiedź nie poprawną. \nProszę wybrać jedną z dostępnych opcji. \nProsze nacisnąć ENTER aby kontynuować.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void dod()
        {
            int leng = l.Lista.Count();

            do
            {
                Console.WriteLine("Proszę podać nazwę Produktu do dodania.");
                string nazw = Console.ReadLine();

                if (string.IsNullOrEmpty(nazw))
                {
                    Console.WriteLine("Nie podano nazwy wydatku");
                    continue;
                }

                do
                {
                    Console.WriteLine("Proszę podać wartość wydatku");
                    if (Int32.TryParse(Console.ReadLine(), out int cen))//Upewnia się że podana odpowiedź jest liczbą (int) a następnie pozwala skorzystać z niej
                    {
                        if (cen > 0)
                        {
                            l.Lista.Add(new Data { ID = leng + 1, Nazwa = nazw, Cena = cen });
                            Console.WriteLine("Wydatek dodany pomyślnie. \nProszę nacisnąć ENTER aby kontynuować");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Podano wydatek negatywny. \nProszę nacisnąć ENTER aby kontynuować.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podano niepoprawną wartość albo nie podano wartości w ogóle");
                    }
                } while (true);
            } while (false);
        }

        static void wys()
        {
            if (l.Lista.Count == 0)
            {
                Console.WriteLine("Lista wydatków jest pusta.");
            }
            else
            {
                foreach (var item in l.Lista)
                {
                    Console.WriteLine($"ID: {item.ID}, Nazwa: {item.Nazwa}, Cena: {item.Cena}");
                }
            }
            Console.WriteLine("Proszę nacisnąć ENTER aby kontynuować");
            Console.ReadLine();
            Console.Clear();
        }

        static void obl()
        {
            int suma = l.Lista.Sum(x => x.Cena);
            Console.WriteLine($"Łączna kwota wydatków: {suma}");
            Console.WriteLine("Proszę nacisnąć ENTER aby kontynuować");
            Console.ReadLine();
            Console.Clear();
        }

        static void najw()
        {
            if (l.Lista.Count == 0)
            {
                Console.WriteLine("Lista wydatków jest pusta.");
            }
            else
            {
                var najwyzszy = l.Lista.OrderByDescending(x => x.Cena).First();
                Console.WriteLine($"Wydatek o najwyższej wartości: ID: {najwyzszy.ID}, Nazwa: {najwyzszy.Nazwa}, Cena: {najwyzszy.Cena}");
            }
            Console.WriteLine("Proszę nacisnąć ENTER aby kontynuować");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
