public class ChessBoard
{
    private Cell[,] _cells;

    public ChessBoard()
    {
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        _cells = new Cell[8, 8];

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                _cells[x, y] = new Cell(x, y);
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            return _cells[x, y];
        }
        else
        {
            return null;
        }
    }
}
