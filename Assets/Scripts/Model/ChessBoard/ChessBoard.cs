public class ChessBoard
{
    private int _boardSize;
    private Cell[,] _cells;

    public ChessBoard()
    {
        _boardSize = 8;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        _cells = new Cell[_boardSize, _boardSize];

        for (int x = 0; x < _boardSize; x++)
        {
            for (int y = 0; y < _boardSize; y++)
            {
                _cells[x, y] = new Cell(x, y);
            }
        }
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
