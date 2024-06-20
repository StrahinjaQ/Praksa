using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Praksa
{ 
    public interface InterfaceNodeAStar : InterfaceAlgoritam
    {
        void Initialize(); //Ovakve stvari ne treba da budu deo interfejsa, vec se skrivaju u klasi
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
