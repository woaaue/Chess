using UnityEngine;

public sealed class Bishop : Figure
{
    public override FigureType Type => FigureType.Bishop;

    public Bishop(Cell startCell, Color color)
    {
        CurrentCell = startCell;
        Color = color;
    }

    public override bool IsValidMove(Cell targetCell, ChessBoard chessBoard)
    {
        int deltaX = targetCell.X - CurrentCell.X;
        int deltaY = targetCell.Y - CurrentCell.Y;

        if (Mathf.Abs(deltaX) != Mathf.Abs(deltaY) || deltaX == 0 || deltaY == 0)
        {
            return false;
        }
            
        int directionX = deltaX > 0 ? 1 : -1;
        int directionY = deltaY > 0 ? 1 : -1;

        for(int i = 1; i < Mathf.Abs(deltaX); i++)
        {
            Cell nextCell = chessBoard.GetCell(CurrentCell.X + i * directionX, CurrentCell.Y + i * directionY);
            
            if(!nextCell.IsEmpty)
            {
                return false;
            }
        }

        return true;
    }

    public override void Move(Cell targetCell, ChessBoard chessBoard)
    {
        base.Move(targetCell, chessBoard);
    }
}
