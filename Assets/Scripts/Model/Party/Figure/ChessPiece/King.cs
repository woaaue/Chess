using UnityEngine;

public sealed class King : Figure
{
    public override FigureType Type => FigureType.King;

    public King(Cell startCell, Color color)
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

        if (targetCell.X == CurrentCell.X && deltaY != 0 && deltaY < 2)
        {
            if (chessBoard.GetFigure(targetCell).Color != Color && Mathf.Abs(targetCell.Y - CurrentCell.Y) == 1 && targetCell.X == CurrentCell.X)
            {
                return true;
            }

            if (!targetCell.IsEmpty)
            {
                return false;
            }

            return true;
        }

        if(targetCell.Y == CurrentCell.Y && deltaX != 0 && deltaX < 2)
        {
            if (chessBoard.GetFigure(targetCell).Color != Color && Mathf.Abs(targetCell.X - CurrentCell.X) == 1 && targetCell.Y == CurrentCell.Y)
            {
                return true;
            }

            if (!targetCell.IsEmpty)
            {
                return false;
            }

            return true;
        }

        if (Mathf.Abs(deltaX) == 1 && Mathf.Abs(deltaY) == 1)
        {
            for (int i = 1; i <= Mathf.Abs(deltaX); i++)
            {
                Cell nextCell = chessBoard.GetCell(CurrentCell.X + i * directionX, CurrentCell.Y + i * directionY);

                if (targetCell.X == nextCell.X && targetCell.Y == nextCell.Y && chessBoard.GetFigure(targetCell).Color != Color)
                {
                    return true;
                }

                if (!nextCell.IsEmpty)
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
