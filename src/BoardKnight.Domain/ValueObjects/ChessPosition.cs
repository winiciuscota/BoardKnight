using System;
using System.Linq;

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
        Y = positionStr[1];
    }

    public string AlgebraicNotation
    {
        get
        {
            return $"{Number2String(X)}{Y}";
        }
    }

    private String Number2String(int number)

    {
        Char c = (Char)(97 + (number - 1));
        return c.ToString();
    }

    private int Char2Number(Char c) {
        return char.ToUpper(c) - 64;
    } 
}