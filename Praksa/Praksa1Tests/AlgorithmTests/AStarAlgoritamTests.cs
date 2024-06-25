using Praksa.Algorithms;

namespace Praksa1Tests.AlgorithmTests
{
    public class AStarAlgoritamTests
    {
        [Fact]
        public void InitializeTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);

            // Act
            algorithm.Initialize();

            // Assert
            Assert.NotNull(algorithm.GetNodes());
            Assert.Equal(0, algorithm.GetNodes()[start.Item1, start.Item2].G);
        }

        [Fact]
        public void CalculateHeuristicTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var node = new Node(2, 2);

            // Act
            double heuristic = algorithm.CalculateHeuristic(node);

            // Assert
            Assert.Equal(4, heuristic);
        }

        [Fact]
        public void GetNeighborsTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var node = new Node(2, 2);

            // Act
            var neighbors = algorithm.GetNeighbors(node);

            // Assert
            Assert.Equal(8, neighbors.Count());
        }

        [Fact]
        public void UpdateOpenListTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var startNode = algorithm.GetNodes()[start.Item1, start.Item2];
            var openList = new SortedSet<Node> { startNode };
            var closedList = new HashSet<Node>();

            // Act
            algorithm.UpdateOpenList(startNode, closedList, openList);

            // Assert
            Assert.True(openList.Count > 1);
        }

        [Fact]
        public void IsGoalTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var goalNode = new Node(goal.Item1, goal.Item2);

            // Act
            bool result = algorithm.IsGoal(goalNode);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCostTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var currentNode = new Node(2, 2);
            var neighbor = new Node(2, 3);

            // Act
            double cost = algorithm.GetCost(currentNode, neighbor);

            // Assert
            Assert.True(cost >= 0);
        }

        [Fact]
        public void ReconstructPathTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var node = new Node(goal.Item1, goal.Item2) { Parent = new Node(3, 3) };

            // Act
            string path = algorithm.ReconstructPath(node);

            // Assert
            Assert.Contains("(3, 3)", path);
            Assert.Contains("(4, 4)", path);
        }

        [Fact]
        public void GetAllNodesTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);

            // Act
            var allNodes = algorithm.GetAllNodes();

            // Assert
            Assert.Equal(25, allNodes.Count());
        }

        [Fact]
        public void GetNodesTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);

            // Act
            var nodes = algorithm.GetNodes();

            // Assert
            Assert.Equal(5, nodes.GetLength(0));
            Assert.Equal(5, nodes.GetLength(1));
        }

        [Fact]
        public void UpdateNodeCostsTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new AStarAlgoritam(grid, start, goal);
            var nodes = algorithm.GetNodes();

            // Act
            algorithm.UpdateNodeCosts(nodes);

            // Assert
            Assert.Equal(0, nodes[start.Item1, start.Item2].G);
            Assert.Equal(double.MaxValue, nodes[goal.Item1, goal.Item2].G);
        }
    }
}
