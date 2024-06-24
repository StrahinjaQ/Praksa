using System;
using System.Collections.Generic;
using Praksa1.Algorithms;

namespace Praksa1.RunAlgorithm
{
    public class Selektor
    {
        /*
         * Pravilo je da se polja nazivaju _naziv.
         * PS Jako mi se svidja sto si primenio dizajn pattern
        */

        private readonly Dictionary<string, Type> _algoritmi;
        private Interfaces.InterfaceAlgoritam _algoritam;

        public Selektor()
        {
            _algoritmi = new Dictionary<string, Type>()
                {
                    {"BELLMAN-FORD", typeof(BellmanFordAlgoritam) },
                    {"A*", typeof(AStarAlgoritam) }
                };
        }

        public Interfaces.InterfaceAlgoritam GetAlgoritam(string choice, int[,] grid, (int, int) start, (int, int) goal)
        {
            if (_algoritmi.TryGetValue(choice.ToUpper(), out Type algorithmType))
            {
                _algoritam = (Interfaces.InterfaceAlgoritam)Activator.CreateInstance(algorithmType, grid, start, goal);
                return _algoritam;
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
