using System;
using System.Collections.Generic;
using System.Linq;
using BoardKnight.Domain.ValueObjects;

namespace BoardKnight.Domain
{
    public class BoardKnightPredictor
    {
        private List<(int x, int y)> _moves;

        public BoardKnightPredictor()
        {
            // List of all possible moves for the knight
            _moves = new List<(int x, int y)> { (-2, 1), (-2, -1), (-1, 2), (1, 2), (2, 1), (2, -1), (-1, -2), (1, -2) };
        }
        public IEnumerable<ChessPosition> GetPossiblePositions(ChessPosition position)
        {
            foreach (var move in _moves)
            {
                var newPosition = position.GetPosition(move.x, move.y);
                // Return only if this is a valid position
                if (newPosition.Valid)
                    yield return newPosition;
            }
        }

        public IEnumerable<ChessPosition> GetPossiblePositionsWith2Moves(ChessPosition position)
        {
            var firstMovePositions = GetPossiblePositions(position);
            return firstMovePositions.SelectMany(x => GetPossiblePositions(x)).Distinct();
        }

    }
}
