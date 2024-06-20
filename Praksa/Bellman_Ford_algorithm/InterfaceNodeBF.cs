using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Praksa
{
    // Ovo je reminder da prokomentarisem arhitekturu, nemoj ga brisati da ostane kad se cujemo. Ostale brisi
    public interface InterfaceNodeBF : InterfaceAlgoritam
    {
        void Initialize();
        void InitializeNodeCosts(Node[,] nodes); // Takodje nikakva inicijalizacija ne ide zajedno
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
