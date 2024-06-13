using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{
    internal class Program
    {
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
            var goal = (5, 5);

            //
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
        }


        //u ovoj klasi se izabrani algoritam poziva
        public class Selektor
        {
            private readonly Dictionary<string, Type> algoritmi;

            public Selektor()
            {
                algoritmi = new Dictionary<string, Type>()
            {
                {"BELLMAN-FORD", typeof(BellmanFordAlgoritam) },
                {"A*", typeof(AStarAlgoritam) }
            };
            }

            public InterfaceAlgoritam GetAlgoritam(string choice, int[,] grid, (int, int) start, (int, int) goal)
            {
                if (algoritmi.TryGetValue(choice.ToUpper(), out Type algorithmType))
                {
                    return (InterfaceAlgoritam)Activator.CreateInstance(algorithmType, grid, start, goal);
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
