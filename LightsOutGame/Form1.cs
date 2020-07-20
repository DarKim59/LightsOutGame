using LightsOutGame.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LightsOutGame
{
    public partial class Form1 : Form
    {
        private int GridOffset = 50;
        private int GridLength = 250;
        private readonly IGameGridService _gameGrid;

        public Form1(IGameGridService gameGrid)
        {
            InitializeComponent();
            _gameGrid = gameGrid;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int cellLength = GridLength / _gameGrid.NumCells;

            for (int r = 0; r < _gameGrid.NumCells; r++)
            {
                for (int c = 0; c < _gameGrid.NumCells; c++)
                {
                    Brush brush;
                    Pen pen;

                    //if (grid[r, c])
                    if (_gameGrid.GetBoardValue(r, c))
                    {
                        pen = Pens.Black;
                        brush = Brushes.White;
                    }
                    else
                    {
                        pen = Pens.White;
                        brush = Brushes.Black;
                    }

                    int x = c * cellLength + GridOffset;
                    int y = r * cellLength + GridOffset;

                    g.DrawRectangle(pen, x, y, cellLength, cellLength);
                    g.FillRectangle(brush, (x + 1), (y + 1), (cellLength - 1), (cellLength - 1));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int cellLength = GridLength / _gameGrid.NumCells;

            // Make sure click was inside the grid
            if (e.X < GridOffset || e.X > cellLength * _gameGrid.NumCells + GridOffset ||
                e.Y < GridOffset || e.Y > cellLength * _gameGrid.NumCells + GridOffset)
                return;

            // Find row, col of mouse press
            int r = (e.Y - GridOffset) / cellLength;
            int c = (e.X - GridOffset) / cellLength;

            // Invert selected box and all surrounding boxes
            _gameGrid.InvertTileSelection(r, c);

            // Redraw grid
            this.Invalidate();

            // Check to see if puzzle has been solved
            if (_gameGrid.GameWon())
            {
                // Display winner dialog box just inside window
                MessageBox.Show(this, Resource.Won, @"Lights Out!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gameGrid.StartNewGame();
            Invalidate(); // Redraw the grid
        }
    }
}
