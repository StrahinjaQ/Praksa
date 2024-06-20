using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{

    // CR Generalno drzi se jednog jezika bio to engleski ili srpski. Pobrisi sve usinge koje ne koristis. Takodje, prebaci klase u namespaceove i foldere. Nemoj dodavati klase u isti fajl :)

    public class Program
    {
        // Prebaci logiku u neku klasu Algorithms nesto tako
        static void Main(string[] args)
        {   
            //inicijalizacija masumicnog grafa sa pocetkom i krajem
            var selector = new Selektor();

            int[,] grid = {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 0 }
        };

            var start = (0, 0);
            var goal = (4, 4);

            Console.Write("Koji algoritam zelite da koristite(A* ili Bellman-Ford): "); // Sve sto ispisujes treba sakriti u klasu, ovaj komentar ostavi da prodiskutujemo na sledecem syncu takodje.
            string userChoice = Console.ReadLine().Trim();

            try
            {
                string result = selector.Izvrsavanje(userChoice, grid, start, goal);
                Console.WriteLine(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            

            // Čekanje na unos korisnika pre nego što se prozor zatvori
            Console.WriteLine("\nPritisnite Enter za zatvaranje aplikacije...");
            Console.ReadLine();
        }


        //u ovoj klasi se izabrani algoritam poziva
        public class Selektor
        {
            // Pravilo je da se polja nazivaju _naziv.
            // PS Jako mi se svidja sto si primenio dizajn pattern
            private readonly Dictionary<string, Type> algoritmi;
            private InterfaceAlgoritam algoritam;

            public Selektor()
            {
                algoritmi = new Dictionary<string, Type>()
                {
                    {"BELLMAN-FORD", typeof(BellmanFordAlgoritam) },
                    {"A*", typeof(AStarAlgoritam) }
                };
            }


            // CR visak metoda

            public void AddAlgorithm(string name, Type algorithmType)
            {
                algoritmi[name] = algorithmType;
            }

            public InterfaceAlgoritam GetAlgoritam(string choice, int[,] grid, (int, int) start, (int, int) goal)
            {
                if (algoritmi.TryGetValue(choice.ToUpper(), out Type algorithmType))
                {
                    algoritam = (InterfaceAlgoritam)Activator.CreateInstance(algorithmType, grid, start, goal);
                    return algoritam;
                }
                else
                {
                    throw new ArgumentException($"Algoritam '{choice}' nije podrzan.");
                }
            }

            public string Izvrsavanje(string choice, int[,] grid, (int, int) start, (int, int) goal)
            {
                var algoritam = GetAlgoritam(choice, grid, start, goal);
                return algoritam.Run();
            }
        }
    }
}
