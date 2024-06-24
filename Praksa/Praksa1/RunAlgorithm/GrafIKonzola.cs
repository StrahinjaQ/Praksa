using System;

namespace Praksa1.RunAlgorithm
{
    public class GrafIKonzola
    {
        public static void Run()
        {
            //inicijalizacija nasumicnog grafa sa pocetkom i krajem
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

            /*
             * Sve sto ispisujes treba sakriti u klasu, ovaj komentar ostavi da prodiskutujemo na sledecem syncu takodje.
             */

            Console.Write("Koji algoritam zelite da koristite(A* ili Bellman-Ford): ");
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
    }
}
        
