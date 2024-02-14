using UnityEngine;

public sealed class Pawn : Figure
{
    public override FigureType Type => FigureType.Pawn;
    private bool _isFirstMove = true;

    public Pawn(Cell startCell, Color color)
    {
        CurrentCell = startCell;
        Color = color;
    }

    public override bool IsValidMove(Cell targetCell, ChessBoard chessBoard)
    {
        if (CurrentCell == targetCell)
            return false;

        if (this.Color == Color.white)
        {
            return IsPossibleMove(2, 1);
        }
        else
        {
           return IsPossibleMove(-2, -1);
        }

        bool IsPossibleMove(int directionFirstMove, int defaultMove)
        {
            if (targetCell.IsEmpty)
            {
                if (_isFirstMove && targetCell.X == CurrentCell.X && targetCell.Y == CurrentCell.Y + directionFirstMove)
                {
                    _isFirstMove = false;
                    return true;
                }
                else if (targetCell.X == CurrentCell.X && targetCell.Y == CurrentCell.Y + defaultMove)
                {
                    _isFirstMove = false;
                    return true;
                }
            }
            else
            {
                if (chessBoard.GetFigure(targetCell).Color != Color && Mathf.Abs(targetCell.X - CurrentCell.X) == 1 && targetCell.Y == CurrentCell.Y + defaultMove)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public override void Move(Cell targetCell, ChessBoard chessBoard)
    {
        base.Move(targetCell, chessBoard);
    }
}
