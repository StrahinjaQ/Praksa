using Praksa.Algorithms;

namespace Praksa1Tests.AlgorithmTests
{
    public class BellmanFordAlgoritamTests
    {
        [Fact]
        public void InitializeTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);

            // Act
            algorithm.Initialize();

            // Assert
            Assert.NotNull(algorithm.GetNodes());
        }

        [Fact]
        public void InitializeNodeCostsTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var nodes = algorithm.GetNodes();

            // Act
            algorithm.InitializeNodeCosts(nodes);

            // Assert
            Assert.Equal(0, nodes[start.Item1, start.Item2].G);
            Assert.Equal(double.MaxValue, nodes[goal.Item1, goal.Item2].G);
        }

        [Fact]
        public void GetNeighborsTest()
        {
            // Arrange
            int[,] grid = new int[5, 5];
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var node = new Node(2, 2);

            // Act
            var neighbors = algorithm.GetNeighbors(node);

            // Assert
            Assert.Equal(4, neighbors.Count());
        }

        [Fact]
        public void RelaxEdgesTest()
        {
            // Arrange
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var nodes = algorithm.GetNodes();
            algorithm.InitializeNodeCosts(nodes);

            // Act
            algorithm.RelaxEdges(nodes);

            // Assert
            var goalNode = nodes[goal.Item1, goal.Item2];
            Assert.NotEqual(double.MaxValue, goalNode.G);
        }

        [Fact]
        public void RelaxEdgeTest()
        {
            // Arrange
            var u = new Node(0, 0) { G = 0 };
            var v = new Node(0, 1) { G = double.MaxValue };

            var algorithm = new BellmanFordAlgoritam(new int[1, 1], (0, 0), (0, 0));

            // Act
            algorithm.RelaxEdge(u, v);

            // Assert
            Assert.Equal(1, v.G);
            Assert.Equal(u, v.Parent);
        }

        [Fact]
        public void CheckForNegativeCyclesTest()
        {
            // Arrange
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var nodes = algorithm.GetNodes();
            algorithm.InitializeNodeCosts(nodes);
            algorithm.RelaxEdges(nodes);

            // Act
            var hasNegativeCycles = algorithm.CheckForNegativeCycles(nodes);

            // Assert
            Assert.False(hasNegativeCycles);
        }

        [Fact]
        public void ReconstructPathTest()
        {
            // Arrange
            var goalNode = new Node(4, 4) { Parent = new Node(3, 3) };

            var algorithm = new BellmanFordAlgoritam(new int[1, 1], (0, 0), (0, 0));

            // Act
            var path = algorithm.ReconstructPath(goalNode);

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
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();

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
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();

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
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var nodes = algorithm.GetNodes();

            // Act
            algorithm.UpdateNodeCosts(nodes);

            // Assert
            Assert.Equal(0, nodes[start.Item1, start.Item2].G);
            Assert.Equal(double.MaxValue, nodes[goal.Item1, goal.Item2].G);
        }

        [Fact]
        public void RelaxingNodeTest()
        {
            // Arrange
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            var algorithm = new BellmanFordAlgoritam(grid, start, goal);
            algorithm.Initialize();
            var nodes = algorithm.GetNodes();
            algorithm.InitializeNodeCosts(nodes);

            // Act
            algorithm.RelaxingNode(nodes);

            // Assert
            var goalNode = nodes[goal.Item1, goal.Item2];
            Assert.NotEqual(double.MaxValue, goalNode.G);
        }
    }
}
