using System;
using System.Collections.Generic;
using System.Linq;
using BoardKnight.Domain;
using Xunit;

namespace BoardKnight.Tests.Domain
{
    public class BoardKnightPredictorTests
    {
        [Theory]
        [InlineData("d4", new string[] { "b5", "c6", "e6", "f5", "b3", "c2", "e2", "f3" })]
        [InlineData("h1", new string[] { "f2", "g3" })]
        public void GetPossibleMoves_Test(string positionStr, string[] possibleMoves)
        {
            var predictor = new BoardKnightPredictor();
            var predictedValues = predictor.GetPossibleMoves(new ChessPosition(positionStr))
                                            .Select(x => x.AlgebraicNotation).ToArray();

            var result = Enumerable.SequenceEqual(predictedValues, possibleMoves);

            Assert.Equal(true, result);
        }
    }
}
