namespace LightsOutGame.Interfaces
{
    public interface IGameGrid
    {
        int NumCells { get; set; }
        void StartNewGame();
        bool GetBoardValue(int row, int col);
        void InvertTileSelection(int row, int col);
        bool GameWon();
    }
}