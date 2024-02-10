using UnityEngine;

public abstract class Figure
{
    public abstract FigureType Type { get;}
    public Color Color { get; private protected set; }
    public Cell CurrentCell { get; private protected set; }
    public abstract bool IsValidMove(Cell targetCell, ChessBoard chessBoard);

    public virtual void Move(Cell targetCell, ChessBoard chessBoard)
    {
        targetCell.SetFigure(this);
        CurrentCell.Clear();
        CurrentCell = targetCell;
    }
}

