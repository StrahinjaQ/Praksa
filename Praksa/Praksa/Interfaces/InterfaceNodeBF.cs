using Praksa.Algorithms;

namespace Praksa.Interfaces
{
    /*
     * Ovo je reminder da prokomentarisem arhitekturu, nemoj ga brisati da ostane kad se cujemo. Ostale brisi
    */

    public interface InterfaceNodeBF : InterfaceAlgoritam
    {
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
