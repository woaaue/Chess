using UnityEngine;

public class ChessBoard
{

    private int _boardSize;
    public Cell[,] Cells { get; private set; }

    public ChessBoard()
    {
        _boardSize = 8;
        InitializeBoard();
        FillBoard();
    }

    private void InitializeBoard()
    {
        Cells = new Cell[_boardSize, _boardSize];

        for (int x = 0; x < _boardSize; x++)
        {
            for (int y = 0; y < _boardSize; y++)
            {
                Cells[x, y] = new Cell(x, y);
            }
        }
    }

    private void FillBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            PlaceFigure(GetCell(i, 1), new Pawn(GetCell(i, 1), Color.white));
            PlaceFigure(GetCell(i, 6), new Pawn(GetCell(i, 6), Color.black));
        }

        PlaceFigure(GetCell(0, 0), new Rook(GetCell(0, 0), Color.white));
        PlaceFigure(GetCell(7, 0), new Rook(GetCell(7, 0), Color.white));
        PlaceFigure(GetCell(0, 7), new Rook(GetCell(0, 7), Color.black));
        PlaceFigure(GetCell(7, 7), new Rook(GetCell(7, 7), Color.black));

        PlaceFigure(GetCell(1, 0), new Knight(GetCell(1, 0), Color.white));
        PlaceFigure(GetCell(6, 0), new Knight(GetCell(6, 0), Color.white));
        PlaceFigure(GetCell(1, 7), new Knight(GetCell(1, 7), Color.black));
        PlaceFigure(GetCell(6, 7), new Knight(GetCell(6, 7), Color.black));

        PlaceFigure(GetCell(2, 0), new Bishop(GetCell(2, 0), Color.white));
        PlaceFigure(GetCell(5, 0), new Bishop(GetCell(5, 0), Color.white));
        PlaceFigure(GetCell(2, 7), new Bishop(GetCell(2, 7), Color.black));
        PlaceFigure(GetCell(5, 7), new Bishop(GetCell(5, 7), Color.black));

        PlaceFigure(GetCell(3, 0), new Queen(GetCell(3, 0), Color.white));
        PlaceFigure(GetCell(4, 0), new King(GetCell(4, 0), Color.white));
        PlaceFigure(GetCell(3, 7), new Queen(GetCell(3, 7), Color.black));
        PlaceFigure(GetCell(4, 7), new King(GetCell(4, 7), Color.black));
    }

    public Cell GetCell(int x, int y)
    {
        if (BoardUtils.IsValidPosition(x, y, _boardSize))
        {
            return Cells[x, y];
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
