using LightsOutGame.Services;
using Moq;
using Xunit;
using LightsOutGame.Interfaces;
using Moq;

namespace LightsOutGameTests.Services
{
    public class GameGridServiceTests
    {
        private GameGridService _sut;
        private Mock<IGameGridService> _gameGrid;

        [Fact]
        public void Given_When_I_Call_StartNewGame_Then_The_A_GameGrid_with_5_cells_Is_SetUp()
        {
            //act
            var result = _sut = new GameGridService();

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
        public void Given_When_I_Call_GetBoardValue_With_Positive_Values_Then_True_Is_Returned(int row, int col)
        {
            //arrange and act
            var result = _sut = new GameGridService();
            var boardValue = result.GetBoardValue(row, col);

            //assert
            Assert.NotNull(result);
            Assert.True(boardValue);
        }

        [Fact]
        public void Given_When_I_Call_GetBoardValue_With_Negative_Values_Then_True_An_Exception_Is_Thrown()
        {
            //arrange
            _sut = new GameGridService();

            // act and assert
            Assert.Throws<System.IndexOutOfRangeException>(() => _sut.GetBoardValue(-2, -2));
        }

        [Fact]
        public void Given_When_I_Call_GameWon_With_default_Grid_The_Game_Is_Not_Won()
        {
            //arrange
            
            _sut = new GameGridService();

            // act and assert
            bool gameWon = _sut.GameWon();

            Assert.False(gameWon);
        }

        [Fact]
        public void NumCells_StoresCorrectly()
        {
            _sut = new GameGridService
            {
                NumCells = 3
            };
            Assert.Equal(3, _sut.NumCells);
        }

        [Fact (Skip = "Not fully implemented")]
        public void Given_I_Call_GameGridService_Then_The_Correct_Methods_Are_Called_To_Start_A_New_Game()
        {
            //arrange

            //act
            _sut = new GameGridService();

            //assert
            _gameGrid.Verify(v => v.StartNewGame(), Times.Once);
        }

        [Fact(Skip = "Not fully implemented")]
        public void Given_When_I_Call_GameWon_With_A_Winning_Grid_The_Game_Is_Won()
        {
            //arrange
            bool[,] _grid;
            _grid = new bool[5, 5]; //Create Grid
            _grid[0, 0] = false;
            _grid[0, 1] = false;

            _gameGrid = new Mock<IGameGridService>();
            _gameGrid.Setup(b => b.NumCells).Returns(It.IsAny<int>());

            var result = _sut = new GameGridService();

            // act and assert
            //TO DO
        }
    }
}
