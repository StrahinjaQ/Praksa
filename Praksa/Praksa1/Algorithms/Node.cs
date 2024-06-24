using System;

namespace Praksa1.Algorithms
{
    //posto je cvor isti za oba algoritma odvojeno ga inicijalizujem u ovoj klasi
    public class Node : IComparable<Node>
    {
        public int X { get; }
        public int Y { get; }
        public double G { get; set; } // Cena od starta do trenutnog cvora
        public double H { get; set; } // Heuristicka cena od trenutog cvora do cilja
        public double F => G + H;     // Ukupna cena: F = G + H
        public Node Parent { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            G = double.MaxValue;
            H = 0;
            Parent = null;
        }

        public override bool Equals(object obj)
        {
            if (obj is Node other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }

        public override string ToString()
        {
            return $"({X}, {Y}) - G: {G}, H: {H}, F: {F}";
        }

        public int CompareTo(Node other)
        {
            if (other == null) return 1;
            return F.CompareTo(other.F);
        }
    }
}
