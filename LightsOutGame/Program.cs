using System;
using System.Windows.Forms;
using LightsOutGame.Services;
using LightsOutGame.Interfaces;

namespace LightsOutGame
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IGameGridService gameGrid = new GameGridService();
            Application.Run(new Form1(gameGrid));
        }
    }
}
