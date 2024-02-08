using UnityEngine;

public sealed class Queen : Figure
{
    public override FigureType Type => FigureType.Queen;

    public Queen(Cell startCell, Color color)
    {
        CurrentCell = startCell;
        Color = color;
    }

    public override bool IsValidMove(Cell targetCell, ChessBoard chessBoard)
    {
        int deltaX = targetCell.X - CurrentCell.X;
        int deltaY = targetCell.Y - CurrentCell.Y;

        //if (Mathf.Abs(deltaX) != Mathf.Abs(deltaY) || targetCell.X != CurrentCell.X && deltaY == 0 
        //    || targetCell.Y != CurrentCell.Y && deltaX == 0 || deltaX == 0 && deltaY == 0)
        //{
        //    return false;
        //} TO DO: условие под вопросом нужности.

        int directionX = deltaX > 0 ? 1 : -1;
        int directionY = deltaY > 0 ? 1 : -1;

        if (Mathf.Abs(deltaX) == Mathf.Abs(deltaY))
        {
            for (int i = 1; i < Mathf.Abs(deltaX); i++)
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

        if (targetCell.X == CurrentCell.X && deltaY != 0)
        {
            for (int i = 1; i < Mathf.Abs(deltaY); i++)
            {
                Cell nextCell = chessBoard.GetCell(CurrentCell.X, CurrentCell.Y + i * directionY);

                if (targetCell.Y == nextCell.Y && chessBoard.GetFigure(targetCell).Color != Color)
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

        if (targetCell.Y == CurrentCell.Y && deltaX != 0)
        {
            for (int i = 0; i < Mathf.Abs(deltaX); i++)
            {
                Cell nextCell = chessBoard.GetCell(CurrentCell.X + i * directionX, CurrentCell.Y);

                if (targetCell.X == nextCell.X && chessBoard.GetFigure(targetCell).Color != Color)
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
