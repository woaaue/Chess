using UnityEngine;

public class ChessBoard
{
    private int _boardSize;
    private Cell[,] _cells;

    public ChessBoard()
    {
        _boardSize = 8;
        InitializeBoard();
        FillBoard();
    }

    private void InitializeBoard()
    {
        _cells = new Cell[_boardSize, _boardSize];

        for (int y = 0; y < _boardSize; y++)
        {
            for (int x = 0; x < _boardSize; x++)
            {
                _cells[y, x] = new Cell(_boardSize - y, x + 1);
            }
        }
    }

    private void FillBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            PlaceFigure(GetCell(1, i), new Pawn(GetCell(1, i), Color.white));
            PlaceFigure(GetCell(6, i), new Pawn(GetCell(6, i), Color.black));
        }

        PlaceFigure(GetCell(0, 0), new Rook(GetCell(0, 0), Color.white));
        PlaceFigure(GetCell(0, 7), new Rook(GetCell(0, 7), Color.white));
        PlaceFigure(GetCell(7, 0), new Rook(GetCell(7, 0), Color.black));
        PlaceFigure(GetCell(7, 7), new Rook(GetCell(7, 7), Color.black));

        PlaceFigure(GetCell(0, 1), new Knight(GetCell(0, 1), Color.white));
        PlaceFigure(GetCell(0, 6), new Knight(GetCell(0, 6), Color.white));
        PlaceFigure(GetCell(7, 1), new Knight(GetCell(7, 1), Color.black));
        PlaceFigure(GetCell(7, 6), new Knight(GetCell(7, 6), Color.black));

        PlaceFigure(GetCell(0, 2), new Bishop(GetCell(0, 2), Color.white));
        PlaceFigure(GetCell(0, 5), new Bishop(GetCell(0, 5), Color.white));
        PlaceFigure(GetCell(7, 2), new Bishop(GetCell(7, 2), Color.black));
        PlaceFigure(GetCell(7, 5), new Bishop(GetCell(7, 5), Color.black));

        PlaceFigure(GetCell(0, 3), new Queen(GetCell(0, 3), Color.white));
        PlaceFigure(GetCell(0, 4), new King(GetCell(0, 4), Color.white));
        PlaceFigure(GetCell(7, 3), new Queen(GetCell(7, 3), Color.black));
        PlaceFigure(GetCell(7, 4), new King(GetCell(7, 4), Color.black));
    }

    public Cell GetCell(int x, int y)
    {
        if (BoardUtils.IsValidPosition(x, y, _boardSize))
        {
            return _cells[x, y];
        }
        else
        {
            return null;
        }
    }

    public void ClearCell(Cell cell)
    {
        cell.Clear();
    }

    public void PlaceFigure(Cell cell, Figure figure)
    {
        cell.SetFigure(figure);
    }

    public Figure GetFigure(Cell cell)
    {
        return cell.Figure;
    }

}
