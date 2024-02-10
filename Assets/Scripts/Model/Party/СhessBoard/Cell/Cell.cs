public sealed class Cell 
{
    public int X { get; }
    public int Y { get; }
    public Figure Figure { get; set; }
    public bool IsEmpty => Figure == null;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void SetFigure(Figure figure)
    {
        Figure = figure;
    }

    public void Clear()
    {
        Figure = null;
    }
}
