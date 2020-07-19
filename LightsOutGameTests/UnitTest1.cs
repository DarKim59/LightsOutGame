using LightsOutGame.Classes;
using LightsOutGame.Interfaces;
using Moq;
using Xunit;

namespace LightsOutGameTests
{

    public class UnitTest1
    {

        private Mock<IGameGrid> _gameGrid;
        private GameGrid _sut;

        [Fact]
        public void Given_When_I_Call_StartNewGame_Then_The_A_GameGrid_with_5_cells_Is_SetUp()
        {
            //act
            _gameGrid = new Mock<IGameGrid>();
            _gameGrid.Setup(b => b.NumCells).Returns(It.IsAny<int>());

            var result = _sut = new GameGrid();

            //assert
            _sut.StartNewGame();

            Assert.NotNull(result);
            Assert.Equal(5, result.NumCells);

        }


        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Given_When_I_Call_GetBoardValue_Then_True_Is_Returned(int row, int col)
        {
            //arrange and act
            var result = _sut = new GameGrid();
            var boardValue = result.GetBoardValue(row, col);

            //assert
            Assert.NotNull(result);
            Assert.True(boardValue);

        }

        [Fact]
        public void Given_When_I_Call_GetBoardValue_With_Negative_Values_Then_True_An_Exception_Is_Thrown()
        {
            //arrange
            _sut = new GameGrid();

            // act and assert
            Assert.Throws<System.IndexOutOfRangeException>(() => _sut.GetBoardValue(-2, -2));
        }

        [Fact]
        public void Given_When_I_Call_GameWon_With_default_Grid_The_Game_Is_Not_Won()
        {
            //arrange
            
            _sut = new GameGrid();

            // act and assert
            bool gameWon = _sut.GameWon();

            Assert.False(gameWon);

        }


        //[Fact]
        // TO DO
        //public void Given_When_I_Call_GameWon_With_A_Winning_Grid_The_Game_Is_Won()
        //{
        //    //arrange
        //    bool[,] _grid;
        //    _grid = new bool[5, 5]; //Create Grid
        //    _grid[0, 0] = false;
        //    _grid[0, 1] = false;

        //    _gameGrid = new Mock<IGameGrid>();
        //    _gameGrid.Setup(b => b.NumCells).Returns(It.IsAny<int>());
        //    //_gameGrid.Setup(b => b.

        //    var result = _sut = new GameGrid();

        //    // act and assert
        //    bool gameWon = _sut.GameWon();

        //    Assert.False(gameWon);
        // TO DO
        //}

    }
}
