using Praksa.RunAlgorithm;

namespace Praksa1Tests.RunAlgorithmTests
{
    public class IzvrsavanjeTest
    {
        [Fact]
        public void BellmanFordAlgoritamIzvrsavanjeTest()
        {
            // Arrange
            var selector = new Selektor();
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            string algorithm = "Bellman-Ford";

            // Act
            string result = selector.Izvrsavanje(algorithm, grid, start, goal);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Najkraci put nije nadjen.", result);
            Assert.NotEqual("Detektovan negativni ciklus. Ne postoji najkraci put.", result);
        }

        [Fact]
        public void AStarAlgoritamIzvrsavanjeTest()
        {
            // Arrange
            var selector = new Selektor();
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            string algorithm = "A*";

            // Act
            string result = selector.Izvrsavanje(algorithm, grid, start, goal);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual("Nije pronadjen najkraci put.", result);
        }

        [Fact]
        public void RandomAlgoritamIzvrsavanjeTest()
        {
            // Arrange
            var selector = new Selektor();
            int[,] grid = {
                { 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0 }
            };
            var start = (0, 0);
            var goal = (4, 4);
            string algorithm = "RandomAlgoritam";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => selector.Izvrsavanje(algorithm, grid, start, goal));
        }
    }
}
