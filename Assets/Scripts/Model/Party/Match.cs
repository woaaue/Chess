using System;
using UnityEngine;

public sealed class Match
{
    private ChessBoard _board;
    private Player _currentPlayer;
    public static event Action OnPlayerChanged;
    public static event Action<Player> OnKingDied;
    public Figure _selectedFigure { get; private set; }

    public Match()
    {
        _selectedFigure = null;
        _board = new ChessBoard();
        _currentPlayer = new Player();
    }

    public void SwitchPlayer()
    {
        _currentPlayer = _currentPlayer == Player.White ? Player.Black : Player.White;
    }


    public Cell CoordinateConversion(Vector2 coordinates)
    {
        int x = Mathf.RoundToInt(coordinates.x);
        int y = Mathf.RoundToInt(coordinates.y);
        Cell clickedCell = _board.GetCell(x, y);

        return clickedCell;
    }

    public void IsCellOccupied(Cell clickedCell)
    {
        if (clickedCell != null)
        {
            Figure clickedFigure = _board.GetFigure(clickedCell);

            if (clickedFigure != null)
            {
                if (IsPlayerPiece(clickedFigure, _currentPlayer))
                {
                    _selectedFigure = clickedFigure;
                }
            }
        }
    }

    public bool IsPossibleMove(Figure figure, Cell targetCell)
    {
        if (figure.IsValidMove(targetCell, _board))
        {
            return true;
        }

        return false;
    }

    public void ManipulationFigure(Figure figure, Cell targetCell)
    {
        figure.Move(targetCell, _board);
        _selectedFigure = null;
        OnKingDied?.Invoke(CheckKings(_board));
        OnPlayerChanged?.Invoke();
    }

    private Player CheckKings(ChessBoard board)
    {
        Figure kingWhite = null;
        Figure kingBlack = null;

        foreach (Cell cell in board.Cells)
        {
            if (!cell.IsEmpty)
            {
                if (cell.Figure.Type == FigureType.King && cell.Figure.Color == Color.white)
                {
                    kingWhite = cell.Figure;
                }

                if (cell.Figure.Type == FigureType.King && cell.Figure.Color == Color.black)
                {
                    kingBlack = cell.Figure;
                }
            }
        }

        if (kingWhite == null)
            return Player.Black;
        if (kingBlack == null)
            return Player.White;
        else
            return Player.Draw;

    }

    private bool IsPlayerPiece(Figure figure, Player player)
    {
        if (figure.Color == Color.white && player == Player.White)
        {
            return true;
        }
        else if (figure.Color == Color.black && player == Player.Black)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
