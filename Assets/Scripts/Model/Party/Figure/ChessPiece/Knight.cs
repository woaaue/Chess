using UnityEngine;

public sealed class Knight : Figure
{
    public override FigureType Type => FigureType.Knight;

    public Knight(Cell startCell, Color color)
    {
        CurrentCell = startCell;
        Color = color;
    }

    public override bool IsValidMove(Cell targetCell, ChessBoard chessBoard)
    {
        if (CurrentCell == targetCell)
            return false;

        int deltaX = targetCell.X - CurrentCell.X;
        int deltaY = targetCell.Y - CurrentCell.Y;
        int directionX = deltaX > 0 ? 1 : -1;
        int directionY = deltaY > 0 ? 1 : -1;

        if (Mathf.Abs(deltaX) == 1 && Mathf.Abs(deltaY) == 2)
        {
            if (CurrentCell.Y + Mathf.Abs(deltaY) * directionY == targetCell.Y && CurrentCell.X + Mathf.Abs(deltaX) * directionX == targetCell.X)
            {
                if (targetCell.IsEmpty || chessBoard.GetFigure(targetCell).Color != Color)
                {
                    return true;
                }
                
                if(!targetCell.IsEmpty)
                {
                    return false;
                }
            }

            return true;
        }

        if (Mathf.Abs(deltaX) == 2 && Mathf.Abs(deltaY) == 1)
        {
            if (CurrentCell.X + Mathf.Abs(deltaX) * directionX == targetCell.X && CurrentCell.Y + Mathf.Abs(deltaY) * directionY == targetCell.Y)
            {
                if (targetCell.IsEmpty || chessBoard.GetFigure(targetCell).Color != Color)
                {
                    return true;
                }

                if (!targetCell.IsEmpty)
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    public override void Move(Cell targetCell, ChessBoard chessBoard)
    {
        base.Move(targetCell, chessBoard);
    }
}
