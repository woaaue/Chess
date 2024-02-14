using System;
using UnityEngine;

public abstract class Figure
{
    public abstract FigureType Type { get;}
    public Color Color { get; private protected set; }
    public Cell CurrentCell { get; private protected set; }
    public abstract bool IsValidMove(Cell targetCell, ChessBoard chessBoard);

    public static event Action<Vector2, Vector2> OnLocationChanged;

    public virtual void Move(Cell targetCell, ChessBoard chessBoard)
    {
        OnLocationChanged?.Invoke(new Vector2(targetCell.X, targetCell.Y), new Vector2 (CurrentCell.X, CurrentCell.Y));
        targetCell.SetFigure(this);
        CurrentCell.Clear();
        CurrentCell = targetCell;
    }
}

