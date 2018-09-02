using BoardKnight.Domain.ValueObjects;
using Xunit;

namespace BoardKnight.Tests.Domain.ValueObjects
{
    public class ChessPositionTests
    {
        [Theory]
        [InlineData("d4", 4, 4)]
        [InlineData("d1", 4, 1)]
        [InlineData("g2", 7, 2)]
        public void ChessPositionTest_InitializeFromString(string coords, int x, int y)
        {
            //Given
            var chessPosition = new ChessPosition(coords);
            //When
            //Then
            Assert.Equal(x, chessPosition.X);
            Assert.Equal(y, chessPosition.Y);
        }

        [Theory]
        [InlineData("d4", 4, 4)]
        [InlineData("d1", 4, 1)]
        [InlineData("g2", 7, 2)]
        public void ChessPositionTest_GetCorrectAlgebraicNotation(string coords, int x, int y)
        {
            //Given
            var chessPosition = new ChessPosition(x, y);
            //When

            //Then
            Assert.Equal(coords, chessPosition.AlgebraicNotation);

        }

        [Fact]
        public void ChessPositionTest_GetPosition()
        {
            //Given
            var chessPosition = new ChessPosition("d1");
            //When
            var position = chessPosition.GetPosition(-1, 2);
            //Then
            Assert.Equal("c3", position.AlgebraicNotation);
        }

        [Theory]
        [InlineData(4, 4, true)]
        [InlineData(-4, 4, false)]
        [InlineData(0, 0, false)]
        public void ChessPositionTest_Valid(int x, int y, bool expectedValue)
        {
            //Given
            var chessPosition = new ChessPosition(x, y);
            //When
            //Then
            Assert.Equal(expectedValue, chessPosition.Valid);
        }
    }
}