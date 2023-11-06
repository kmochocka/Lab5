
namespace cwiczenia5
{
    class Program
    {
        static void Zadanie51()
        {
            int[] tablica = new int[5]; 

           
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Podaj {0}. liczbę: ", i + 1);
                tablica[i] = Convert.ToInt32(Console.ReadLine());
            }

            
            int najwiekszyElement = tablica[0];
            int indeksNajwiekszegoElementu = 0;

            for (int i = 1; i < 5; i++)
            {
                if (tablica[i] > najwiekszyElement)
                {
                    najwiekszyElement = tablica[i];
                    indeksNajwiekszegoElementu = i;//lub i+1 zależy czy chcemy wiedzieć na jakim miejscu jest ta liczba bo w tablicy indeksy liczymy od 0
                }
            }

            Console.WriteLine("Największy element: " + najwiekszyElement);
            Console.WriteLine("Indeks największego elementu: " + indeksNajwiekszegoElementu);
        }

        //Napisać program do wykonywania następujących operacji na wektorach
        //Mnożenie wektora przez liczbę
        //Mnożenie wektora przez wektor

        static int[] MnozeniePrzezLiczbe(int[] wektor, int liczba)
        {
            int[] wynik = new int[wektor.Length]; //tworzy się tablica o takiej samej długości co tablica wektor 
            for (int i = 0; i < wektor.Length; i++)
            {
                wynik[i] = wektor[i] * liczba;
            }
            return wynik;
        }

        static int[] MnozeniePrzezWektor(int[] wektor1, int[] wektor2)
        {
            if (wektor1.Length != wektor2.Length)
            {
                Console.WriteLine("Nie można pomnożyć tych wektorów bo mają inną długość!");
                return new int[0];
            }

            int[] wynik = new int[wektor1.Length];
            for (int i = 0; i < wektor1.Length; i++)
            {
                wynik[i] = wektor1[i] * wektor2[i];
            }
            return wynik;
        }

        static void WyswietlWektor(int[] wektor)
        {
            foreach (int element in wektor)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static int[] WczytajWektor()
        {
            Console.Write("Podaj długość wektora: ");
            int dlugosc = Convert.ToInt32(Console.ReadLine());

            int[] wektor = new int[dlugosc];
            for (int i = 0; i < dlugosc; i++)
            {
                Console.Write("Podaj {0}. element wektora: ", i + 1);
                wektor[i] = Convert.ToInt32(Console.ReadLine());
            }

            return wektor;
        }


        static void Zadanie52()
        {
            int[] wektor1 = WczytajWektor();
            int[] wektor2 = WczytajWektor();

            Console.Write("Podaj liczbę przez którą chcesz pomnożyć wektor: ");
            int liczba = Convert.ToInt32(Console.ReadLine());

            int[] wynikMnozeniaLiczba = MnozeniePrzezLiczbe(wektor1, liczba);
            int[] wynikMnozeniaWektor = MnozeniePrzezWektor(wektor1, wektor2);

            Console.WriteLine("\nWynik mnożenia przez liczbę:");
            WyswietlWektor(wynikMnozeniaLiczba);

            Console.WriteLine("\nWynik mnożenia przez wektor:");
            WyswietlWektor(wynikMnozeniaWektor);
        }

        //Napisać program do wykonywania następujących operacji na macierzach
        //Mnożenie macierzy przez liczbę
        //Mnożenie macierzy prze wektor
        //Mnożenie macierzy przez macierz

        static int[,] MnozenieMacierzyPrzezLiczbe(int[,] macierz, int liczba)
        {
            int[,] wynik = new int[macierz.GetLength(0), macierz.GetLength(1)];
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    wynik[i, j] = macierz[i, j] * liczba;
                }
            }
            return wynik;
        }

        static int[] MnozenieMacierzyPrzezWektor(int[,] macierz, int[] wektor)
        {
            if (macierz.GetLength(1) != wektor.Length)
            {
                throw new ArgumentException("Liczba kolumn w macierzy musi być równa długości wektora.");
            }

            int[] wynik = new int[macierz.GetLength(0)];
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    wynik[i] += macierz[i, j] * wektor[j];
                }
            }
            return wynik;
        }

        static int[,] MnozenieMacierzyPrzezMacierz(int[,] macierz1, int[,] macierz2)
        {
            if (macierz1.GetLength(1) != macierz2.GetLength(0))
            {
                throw new ArgumentException("Liczba kolumn w pierwszej macierzy musi być równa liczbie wierszy drugiej macierzy.");
            }

            int[,] wynik = new int[macierz1.GetLength(0), macierz2.GetLength(1)];
            for (int i = 0; i < macierz1.GetLength(0); i++)
            {
                for (int j = 0; j < macierz2.GetLength(1); j++)
                {
                    for (int k = 0; k < macierz1.GetLength(1); k++)
                    {
                        wynik[i, j] += macierz1[i, k] * macierz2[k, j];
                    }
                }
            }
            return wynik;
        }

        static void WyswietlMacierz(int[,] macierz)
        {
            for (int i = 0; i < macierz.GetLength(0); i++)
            {
                for (int j = 0; j < macierz.GetLength(1); j++)
                {
                    Console.Write(macierz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] WczytajMacierz()
        {
            Console.Write("Podaj liczbę wierszy macierzy: ");
            int wiersze = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj liczbę kolumn macierzy: ");
            int kolumny = Convert.ToInt32(Console.ReadLine());

            int[,] macierz = new int[wiersze, kolumny];
            for (int i = 1; i < wiersze + 1; i++)
            {
                for (int j = 1; j < kolumny + 1; j++)
                {
                    Console.Write("Podaj element [{0},{1}] macierzy: ", i, j);
                    macierz[i - 1, j - 1] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return macierz;
        }

        static void Zadanie53()
        {
            int[,] macierz1 = WczytajMacierz();
            int[,] macierz2 = WczytajMacierz();

            int[] wektor = WczytajWektor();

            Console.Write("Podaj liczbę przez którą chcesz pomnożyć macierze i wektor: ");
            int liczba = Convert.ToInt32(Console.ReadLine());

            int[,] wynikMnozeniaLiczba1 = MnozenieMacierzyPrzezLiczbe(macierz1, liczba);
            int[,] wynikMnozeniaLiczba2 = MnozenieMacierzyPrzezLiczbe(macierz2, liczba);
            int[] wynikMnozeniaMacierz1Wektor = MnozenieMacierzyPrzezWektor(macierz1, wektor);
            int[] wynikMnozeniaMacierz2Wektor = MnozenieMacierzyPrzezWektor(macierz2, wektor);
            int[,] wynikMnozeniaMacierz1Macierz2 = MnozenieMacierzyPrzezMacierz(macierz1, macierz2);

            Console.WriteLine("\nMacierz1:");
            WyswietlMacierz(macierz1);

            Console.WriteLine("\nMacierz2:");
            WyswietlMacierz(macierz2);

            Console.WriteLine("\nWynik mnożenia macierzy 1 przez liczbę:");
            WyswietlMacierz(wynikMnozeniaLiczba1);

            Console.WriteLine("\nWynik mnożenia macierzy 2 przez liczbę:");
            WyswietlMacierz(wynikMnozeniaLiczba2);

            Console.WriteLine("\nWynik mnożenia macierzy 1 przez wektor:");
            WyswietlWektor(wynikMnozeniaMacierz1Wektor);

            Console.WriteLine("\nWynik mnożenia macierzy 2 przez wektor:");
            WyswietlWektor(wynikMnozeniaMacierz2Wektor);

            Console.WriteLine("\nWynik mnożenia macierzy 1 i macierzy 2:");
            WyswietlMacierz(wynikMnozeniaMacierz1Macierz2);
        }

        static void WyswietlTablice(int[,] tablica)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(tablica[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Zadanie54()
        {
            int[,] tablica = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j || i == 4 - j)
                    {
                        tablica[i, j] = 1;
                    }
                    else
                    {
                        tablica[i, j] = 0;
                    }
                }
            }

            WyswietlTablice(tablica);
        }

        static void SortujBabelkowo(int[] tablica)
        {
            int n = tablica.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (tablica[j] > tablica[j + 1])
                    {
                        int temp = tablica[j];
                        tablica[j] = tablica[j + 1];
                        tablica[j + 1] = temp;
                    }
                }
            }
        }

        static void WyswietlTablice(int[] tablica)
        {
            foreach (int element in tablica)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        static int[] WczytajTablice()
        {
            Console.Write("Podaj długość tablicy: ");
            int dlugosc = Convert.ToInt32(Console.ReadLine());

            int[] tablica = new int[dlugosc];
            for (int i = 0; i < dlugosc; i++)
            {
                Console.Write("Podaj {0}. element tablicy: ", i + 1);
                tablica[i] = Convert.ToInt32(Console.ReadLine());
            }

            return tablica;
        }

        static void Zadanie55()
        {
            int[] tablica = WczytajTablice();

            Console.WriteLine("Tablica przed sortowaniem:");
            WyswietlTablice(tablica);

            SortujBabelkowo(tablica);

            Console.WriteLine("\nTablica po sortowaniu:");
            WyswietlTablice(tablica);
        }

        static void SortujOdNajwiekszego(int[] tablica)
        {
            int n = tablica.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int najwiekszyIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (tablica[j] > tablica[najwiekszyIndex])
                    {
                        najwiekszyIndex = j;
                    }
                }

                int temp = tablica[i];
                tablica[i] = tablica[najwiekszyIndex];
                tablica[najwiekszyIndex] = temp;
            }
        }


        static void Zadanie56()
        {
            int[] tablica = WczytajTablice();
            Console.WriteLine("Tablica przed sortowaniem:");
            WyswietlTablice(tablica);

            SortujOdNajwiekszego(tablica);

            Console.WriteLine("\nTablica po sortowaniu:");
            WyswietlTablice(tablica);
        }

        static void Main(string[] args)
        {
            //Zadanie51();
            //Zadanie52();
            Zadanie53();
            //Zadanie54();
            //Zadanie55();
            //Zadanie56();
        }

    }
}
