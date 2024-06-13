using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa
{
    public class AStarAlgoritam : InterfaceNodeAStar
    {
        private readonly int[,] _grid;
        private readonly (int, int) _start;
        private readonly (int, int) _goal;
        private Node _startNode;
        private Node _goalNode;

        public AStarAlgoritam(int[,] grid, (int, int) start, (int, int) goal)
        {
            _grid = grid;
            _start = start;
            _goal = goal;
        }

        public void Initialize()
        {
            _startNode = new Node(_start.Item1, _start.Item2) { G = 0, H = CalculateHeuristic(new Node(_start.Item1, _start.Item2)) };
            _goalNode = new Node(_goal.Item1, _goal.Item2);
        }

        public double CalculateHeuristic(Node node)
        {
            return Math.Abs(node.X - _goal.Item1) + Math.Abs(node.Y - _goal.Item2);
        }

        public IEnumerable<Node> GetNeighbors(Node node)
        {
            int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };
            var neighbors = new List<Node>();

            for (int i = 0; i < dx.Length; i++)
            {
                int newX = node.X + dx[i];
                int newY = node.Y + dy[i];

                if (newX >= 0 && newX < _grid.GetLength(0) && newY >= 0 && newY < _grid.GetLength(1) && _grid[newX, newY] == 0)
                {
                    neighbors.Add(new Node(newX, newY));
                }
            }

            return neighbors;
        }

        public void UpdateOpenList(Node currentNode, HashSet<Node> closedList, SortedSet<Node> openList)
        {
            foreach (var neighbor in GetNeighbors(currentNode))
            {
                if (closedList.Contains(neighbor)) continue;

                double tentativeG = currentNode.G + GetCost(currentNode, neighbor);

                if (!openList.Contains(neighbor))
                {
                    neighbor.G = tentativeG;
                    neighbor.H = CalculateHeuristic(neighbor);
                    neighbor.Parent = currentNode;
                    openList.Add(neighbor);
                }
                else if (tentativeG < neighbor.G)
                {
                    neighbor.G = tentativeG;
                    neighbor.Parent = currentNode;
                }
            }
        }

        public bool IsGoal(Node node)
        {
            return node.X == _goal.Item1 && node.Y == _goal.Item2;
        }

        public double GetCost(Node currentNode, Node neighbor)
        {
            return 1; //cena se moze randomizovati
        }

        public double GetTotalCost(Node node)
        {
            return node.G + node.H;
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
            var nodes = new List<Node>();
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    nodes.Add(new Node(i, j));
                }
            }
            return nodes;
        }

        public Node[,] GetNodes()
        {
            var nodes = new Node[_grid.GetLength(0), _grid.GetLength(1)];
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    nodes[i, j] = new Node(i, j);
                }
            }
            return nodes;
        }

        public void UpdateNodeCosts(Node[,] nodes)
        {
            foreach (var node in nodes)
            {
                node.G = double.MaxValue;
            }
            nodes[_start.Item1, _start.Item2].G = 0;
        }

        public string Run()
        {
            Initialize();

            var openList = new SortedSet<Node> { _startNode };
            var closedList = new HashSet<Node>();

            while (openList.Any())
            {
                var currentNode = openList.Min;
                openList.Remove(currentNode);

                if (IsGoal(currentNode))
                {
                    return ReconstructPath(currentNode);
                }

                closedList.Add(currentNode);
                UpdateOpenList(currentNode, closedList, openList);
            }

            return "Nije pronadjen najkraci put.";
        }
    }
}
