using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{
    public interface InterfaceGraph<T> where T : class
    {
        T Graph { get; }

        ICollection<string> Nodes { get; }

        ICollection<Tuple<string, string, int>> Edges { get; }

        string SourceNode { get; }

        int NodeCount { get; }

        int EdgeCount { get; }

        bool NegativeWeightFlag { get; }
    }
}
