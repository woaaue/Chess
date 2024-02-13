using UnityEngine;

public sealed class Match
{
    private ChessBoard _board;
    private Player _currentPlayer;

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
        Debug.Log($"Данные до хода - Фигура: {figure.Type}, Цвет: {figure.Color}, Положение на доске: {figure.CurrentCell.X},{figure.CurrentCell.Y}");
        figure.Move(targetCell, _board);
        Debug.Log($"Данные после хода - Фигура: {figure.Type}, Цвет: {figure.Color}, Положение на доске: {figure.CurrentCell.X},{figure.CurrentCell.Y}");
        _selectedFigure = null;
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
