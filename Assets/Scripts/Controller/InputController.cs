using UnityEngine;

public sealed class GameController : MonoBehaviour
{
    private Camera _camera;
    private ChessBoard _board;
    private Player _currentPlayer;

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

    private void FirstClickCell(Vector2 cellCoordinates)
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

    private Vector2 GetPressCoordinates()
    {
        Vector2 clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        return clickPosition;
    }

    private void ManipulationFigure(Figure figure)
    {
        Debug.Log($"Фигура: {figure.Type}, Цвет: {figure.Color}, Положение на доске: {figure.CurrentCell.X},{figure.CurrentCell.Y}");
    }

    private void Start()
    {
        _camera = Camera.main;
        _board = new ChessBoard();
        _currentPlayer = Player.White;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstClickCell(GetPressCoordinates());
        }
    }
}
