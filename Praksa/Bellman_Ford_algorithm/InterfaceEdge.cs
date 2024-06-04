using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{
    public interface InterfaceEdge<T> where T : class
    {
        T Edge { get; }

        string USNode { get; }

        string DSNode { get; }

        int weight { get; }
    }
}
