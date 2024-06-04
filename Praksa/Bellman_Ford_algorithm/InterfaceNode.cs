using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{
    public interface InterfaceNode<T> where T : class
    {
        string NodeId { get; }

        T Node { get; }

        ICollection<int> dist {  get; }

        ICollection<string> pred { get; }

    }
}
