using System;
using LightsOutGame.Interfaces;

namespace LightsOutGame.Classes
{
    public class GameGrid : IGameGrid
    {
        private int _numberOfCells = 5;
        private bool[,] _grid;
        private readonly Random _rand;

        public int NumCells
        {
            get => _numberOfCells;

            set
            {
                if (value < 3)
                {
                    value = 3;
                }
                else if (value > 5)
                {
                    value = 5;
                }
                _numberOfCells = value;
            }
        }

        public GameGrid()
        {
            _rand = new Random(); // Set up random number generator
            _grid = new bool[_numberOfCells, _numberOfCells]; //Create Grid
            PopulateAndSetUpGrid(false);
        }

        public void StartNewGame()
        {
            _grid = new bool[_numberOfCells, _numberOfCells]; //Create Grid
            PopulateAndSetUpGrid(true);

        }

        public bool GetBoardValue(int row, int col)
        {
            return _grid[row, col];
        }

        public void InvertTileSelection(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            for (int j = col - 1; j <= col + 1; j++)
                if (i >= 0 && i < NumCells && j >= 0 && j < NumCells)
                    _grid[i, j] = !_grid[i, j];
        }

        public bool GameWon()
        {
            for (int r = 0; r < NumCells; r++)
            for (int c = 0; c < NumCells; c++)
                if (_grid[r, c])
                    return false;

            return true;
        }

        private void PopulateAndSetUpGrid(bool newGame)
        {
            for (int r = 0; r < NumCells; r++)
            {
                for (int c = 0; c < NumCells; c++)
                    if (!newGame)
                        _grid[r, c] = true;
                    else
                    {
                        _grid[r, c] = _rand.Next(2) == 1;
                    }

            }

        }
    }


}
