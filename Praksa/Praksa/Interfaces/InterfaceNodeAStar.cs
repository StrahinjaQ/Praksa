using Praksa.Algorithms;

namespace Praksa.Interfaces
{ 
    public interface InterfaceNodeAStar : InterfaceAlgoritam
    {
        double CalculateHeuristic(Node node);
        IEnumerable<Node> GetNeighbors(Node node);
        void UpdateOpenList(Node currentNode, HashSet<Node> closedList, SortedSet<Node> openList);
        bool IsGoal(Node node);
        double GetCost(Node currentNode, Node neighbor);
        double GetTotalCost(Node node);
        string ReconstructPath(Node node);
        IEnumerable<Node> GetAllNodes();
        Node[,] GetNodes();
        void UpdateNodeCosts(Node[,] nodes);
    }
}
