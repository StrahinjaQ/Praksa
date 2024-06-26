﻿using Moq;
using Praksa.Interfaces;
using Praksa.RunAlgorithm;

namespace Praksa1Tests.RunAlgorithmTests
{
    //Testovi se nazivaju NazivklaseTests
    //Nemoj testirati sve kroz jedan test. Ovde testiramo samo selektor i njegovo ponasanje
    public class SelektorTests
    {
        [Fact]
        public void GetAlgoritam_ReturnAStarAlgoritam()
        {
            // Arrange
            var grid = new int[,] { { 0, 0 }, { 0, 0 } };
            var start = (0, 0);
            var goal = (1, 1);

            var mockAStarAlgoritam = new Mock<InterfaceNodeAStar>();
            mockAStarAlgoritam.Setup(a => a.Run()).Returns("A* Path");

            var selector = new Selektor();
            selector.AddAlgoritam("A*", typeof(MockAStarAlgoritam));

            // Act
            var algorithm = selector.GetAlgoritam("A*", grid, start, goal);
            var result = algorithm.Run();

            // Assert
            Assert.IsType<MockAStarAlgoritam>(algorithm);
            Assert.Equal("A* Path", result);
        }

        [Fact]
        public void GetAlgoritam_ReturnBellmanFordAlgoritam()
        {
            // Arrange
            var grid = new int[,] { { 0, 0 }, { 0, 0 } };
            var start = (0, 0);
            var goal = (1, 1);

            var mockBellmanFordAlgoritam = new Mock<InterfaceNodeBF>();
            mockBellmanFordAlgoritam.Setup(a => a.Run()).Returns("Bellman-Ford Path");

            var selector = new Selektor();
            selector.AddAlgoritam("Bellman-Ford", typeof(MockBellmanFordAlgoritam));

            // Act
            var algorithm = selector.GetAlgoritam("Bellman-Ford", grid, start, goal);
            var result = algorithm.Run();

            // Assert
            Assert.IsType<MockBellmanFordAlgoritam>(algorithm);
            Assert.Equal("Bellman-Ford Path", result);
        }

        [Fact]
        public void GetAlgoritam_ThrowArgumentException_WhenChoiceIsInvalid()
        {
            // Arrange
            var grid = new int[,] { { 0, 0 }, { 0, 0 } };
            var start = (0, 0);
            var goal = (1, 1);

            var selector = new Selektor();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => selector.GetAlgoritam("Izbor nije odgovarajuc.", grid, start, goal));
        }

        public class MockAStarAlgoritam : InterfaceAlgoritam
        {
            public string Run()
            {
                return "A* Path";
            }
        }

        public class MockBellmanFordAlgoritam : InterfaceAlgoritam
        {
            public string Run()
            {
                return "Bellman-Ford Path";
            }
        }
    }

    public static class SelektorExtensions
    {
        public static void AddAlgoritam(this Selektor selektor, string name, Type algorithmType)
        {
            selektor.AddAlgoritam(name, algorithmType);
        }
    }
}
