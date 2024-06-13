using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Praksa
{
    public class BellmanFordAlgoritam : InterfaceNodeBF
    {
        private readonly int[,] _grid;
        private readonly (int, int) _start;
        private readonly (int, int) _goal;
        private Node[,] _nodes;
        private readonly int _rows;
        private readonly int _cols;

        public BellmanFordAlgoritam(int[,] grid, (int, int) start, (int, int) goal)
        {
            _grid = grid;
            _start = start;
            _goal = goal;
            _rows = grid.GetLength(0);
            _cols = grid.GetLength(1);
        }

        public void Initialize()
        {
            _nodes = new Node[_rows, _cols];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _nodes[i, j] = new Node(i, j);
                }
            }
        }

        public void InitializeNodeCosts(Node[,] nodes)
        {
            foreach (var node in nodes)
            {
                node.G = double.MaxValue;
            }
            nodes[_start.Item1, _start.Item2].G = 0;
        }

        public IEnumerable<Node> GetNeighbors(Node node)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            var neighbors = new List<Node>();

            for (int i = 0; i < 4; i++)
            {
                int newX = node.X + dx[i];
                int newY = node.Y + dy[i];

                if (newX >= 0 && newX < _rows && newY >= 0 && newY < _cols && _grid[newX, newY] == 0)
                {
                    neighbors.Add(new Node(newX, newY));
                }
            }

            return neighbors;
        }

        public void RelaxEdges(Node[,] nodes)
        {
            for (int k = 0; k < _rows * _cols - 1; k++)
            {
                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _cols; j++)
                    {
                        if (_grid[i, j] == 1) continue;

                        var currentNode = nodes[i, j];
                        foreach (var neighbor in GetNeighbors(currentNode))
                        {
                            RelaxEdge(currentNode, neighbor);
                        }
                    }
                }
            }
        }

        public void RelaxEdge(Node u, Node v)
        {
            double newCost = u.G + 1; //trenutno je cena svake ivice 1, ali moze se staviti neka random vrednost recimo od -2 do 2
            if (newCost < v.G)
            {
                v.G = newCost;
                v.Parent = u;
            }
        }

        public bool CheckForNegativeCycles(Node[,] nodes)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    var currentNode = nodes[i, j];
                    foreach (var neighbor in GetNeighbors(currentNode))
                    {
                        double newCost = currentNode.G + 1; // isto podesiva cena
                        if (newCost < neighbor.G)
                        {
                            return true; // ne bi trebalo da bude negativnih ciklusa posto je cena svake ivice 1 pa ne moze ni otici u minus
                        }
                    }
                }
            }
            return false;
        }

        public string ReconstructPath(Node node)
        {
            var path = new List<(int, int)>();
            while (node != null)
            {
                path.Add((node.X, node.Y));
                node = node.Parent;
            }
            path.Reverse();
            return string.Join(" -> ", path.Select(p => $"({p.Item1}, {p.Item2})"));
        }

        public IEnumerable<Node> GetAllNodes()
        {
            var allNodes = new List<Node>();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    allNodes.Add(_nodes[i, j]);
                }
            }
            return allNodes;
        }

        public Node[,] GetNodes()
        {
            return _nodes;
        }

        public void UpdateNodeCosts(Node[,] nodes)
        {
            foreach (var node in GetAllNodes())
            {
                node.G = double.MaxValue;
            }
            nodes[_start.Item1, _start.Item2].G = 0;
        }

        public void RelaxingNode(Node[,] nodes)
        {
            RelaxEdges(nodes);
        }

        public string Run()
        {
            Initialize();

            var nodes = GetNodes();
            InitializeNodeCosts(nodes);

            RelaxingNode(nodes);

            if (CheckForNegativeCycles(nodes))
            {
                return "Detektovan negativni ciklus. Ne postoji najkraci put.";
            }

            var goalNode = nodes[_goal.Item1, _goal.Item2];
            if (goalNode.G == double.MaxValue)
            {
                return "Najkraci put nije nadjen.";
            }

            return ReconstructPath(goalNode);
        }
    }
}
