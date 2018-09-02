using System;
using System.Linq;

namespace BoardKnight.Domain.ValueObjects
{
    public class ChessPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ChessPosition(string positionStr)
        {
            if (positionStr.Length != 2)
            {
                throw new InvalidOperationException();
            }

            X = Char2Number(positionStr[0]);
            Y = int.Parse(positionStr.Substring(1));
        }

        public ChessPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculate the position if the piece was to move in deltaX and deltaY
        /// </summary>
        /// <param name="deltaX">Move on the x axis</param>
        /// <param name="deltaY">Move on the y axis</param>
        /// <returns></returns>
        public ChessPosition GetPosition(int deltaX, int deltaY)
        {
            return new ChessPosition(X + deltaX, Y + deltaY);
        }

        /// <summary>
        /// Get position in algebraic notation
        /// </summary>
        /// <value></value>
        public string AlgebraicNotation
        {
            get
            {
                return $"{Number2String(X)}{Y}";
            }
        }

        /// <summary>
        /// Convert number to the alphabet letter on it's position
        /// IE: 1 becomes a, 3 becomes c
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private String Number2String(int number)

        {
            Char c = (Char)(97 + (number - 1));
            return c.ToString();
        }

        /// <summary>
        /// Convert char to number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private int Char2Number(Char c)
        {
            return char.ToUpper(c) - 64;
        }

        /// <summary>
        /// check if coordinate is a valid position on the chess board
        /// </summary>
        /// <value></value>
        public bool Valid
        {
            get
            {
                Func<int, bool> validCoord = (x) => x > 0 && x < 9;
                return validCoord(X) && validCoord(Y);
            }
        }
    }
}
