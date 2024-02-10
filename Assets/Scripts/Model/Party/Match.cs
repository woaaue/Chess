using UnityEngine;

public sealed class Match
{
    private ChessBoard _board;
    private Player _currentPlayer;

    public Match()
    {
        _board = new ChessBoard();
        _currentPlayer = new Player();
    }

    private void SwitchPlayer()
    {
        _currentPlayer = (_currentPlayer == Player.White) ? Player.Black : Player.White;
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

    public void FirstClickCell(Vector2 cellCoordinates)
    {
        int x = Mathf.RoundToInt(cellCoordinates.x);
        int y = Mathf.RoundToInt(cellCoordinates.y);

        Cell clickedCell = _board.GetCell(x, y);

        if (clickedCell != null)
        {
            Figure clickedFigure = _board.GetFigure(clickedCell);

            if (clickedFigure != null)
            {
                if (IsPlayerPiece(clickedFigure, _currentPlayer))
                {
                    ManipulationFigure(clickedFigure);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    private void ManipulationFigure(Figure figure)
    {
        Debug.Log($"Фигура: {figure.Type}, Цвет: {figure.Color}, Положение на доске: {figure.CurrentCell.X},{figure.CurrentCell.Y}");
    }
}
