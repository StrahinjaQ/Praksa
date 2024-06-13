using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Praksa
{
    public interface InterfaceNodeBF : InterfaceAlgoritam
    {
        void Initialize();
        void InitializeNodeCosts(Node[,] nodes);
        IEnumerable<Node> GetNeighbors(Node node);
        void RelaxEdges(Node[,] nodes);
        void RelaxEdge(Node u, Node v);
        bool CheckForNegativeCycles(Node[,] nodes);
        string ReconstructPath(Node node);
        IEnumerable<Node> GetAllNodes();
        Node[,] GetNodes();
        void UpdateNodeCosts(Node[,] nodes);
        void RelaxingNode(Node[,] nodes);
    }
}
