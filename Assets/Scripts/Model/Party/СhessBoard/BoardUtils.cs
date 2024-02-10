public static class BoardUtils
{
    public static bool IsValidPosition(int x, int y, int boardSize)
    {      
        return x >= 0 && x < boardSize && y >= 0 && y < boardSize; 
    }
}
