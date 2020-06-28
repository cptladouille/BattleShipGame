using BatailleNavaleApp;
using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Extensions;
using System.Collections.Generic;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class BoardGameTests
    {
        private readonly BoardGame _boardGame;

        public BoardGameTests()
        {
            _boardGame = new BoardGame();
        }

        [Fact]
        public void InitBoardGame_With_Void_Should_Have_100_Cells()
        {
            BoardGame boardGame = new BoardGame();

            boardGame.InitBoardGame();

            Assert.True(boardGame.Cells.Count == 100);
        }
        [Fact]
        public void GetCellsBetween_A1_Cell_And_A5_Cell_Should_Return_List_Of_5_Cells()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A5Coordinate = new BoardCoordinates(1, 5);

            var res = boardGame.GetCellsBetween(boardGame.Cells.At(A1Coordinate), boardGame.Cells.At(A5Coordinate));

            Assert.True(res.Count == 5);
        }

        [Fact]
        public void GetCellsBetween_A1_Cell_And_A5_Cell_Should_Return_List_Of_5_Cells_That_Matches_Cells_A1_To_A5()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A5Coordinate = new BoardCoordinates(1, 5);
            var expectedMatchList = new List<BoardCell>() { boardGame.Cells[0], boardGame.Cells[1], boardGame.Cells[2], boardGame.Cells[3], boardGame.Cells[4] };

            var res = boardGame.GetCellsBetween(boardGame.Cells.At(A1Coordinate), boardGame.Cells.At(A5Coordinate));

            Assert.Equal(expectedMatchList, res);
        }


        [Fact]
        public void GetCellsBetween_A1_Cell_And_D5_Cell_Should_Return_null()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var D5Coordinate = new BoardCoordinates(4, 5);

            var res = boardGame.GetCellsBetween(boardGame.Cells.At(A1Coordinate), boardGame.Cells.At(D5Coordinate));

            Assert.Null(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_At_Not_Parrallel_Coordinates_Should_Return_False()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var D5Coordinate = new BoardCoordinates(4, 5);
            var ship = new AircraftCarrier();

            var res = boardGame.PlaceShipAtCoordinates(ship, A1Coordinate, D5Coordinate);

            Assert.False(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_At_Too_Short_Should_Return_False()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A2Coordinate = new BoardCoordinates(1, 2);
            var ship = new AircraftCarrier();

            var res = boardGame.PlaceShipAtCoordinates(ship, A1Coordinate, A2Coordinate);

            Assert.False(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_At_Too_Long_Should_Return_False()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A8Coordinate = new BoardCoordinates(1, 8);
            var ship = new AircraftCarrier();

            var res = boardGame.PlaceShipAtCoordinates(ship, A1Coordinate, A8Coordinate);

            Assert.False(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_At_Occuped_Should_Return_False()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A3Coordinate = new BoardCoordinates(1, 3);
            var B3Coordinate = new BoardCoordinates(2, 3);
            var A5Coordinate = new BoardCoordinates(1, 5);
            var ship = new AircraftCarrier();
            var occupationShip = new TorpedoBoat();
            boardGame.PlaceShipAtCoordinates(occupationShip, A3Coordinate, B3Coordinate);

            var res = boardGame.PlaceShipAtCoordinates(ship, A1Coordinate, A5Coordinate);

            Assert.False(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_From_A1_Coordinates_To_A5_Coordinates_Should_Return_True()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A5Coordinate = new BoardCoordinates(1, 5);
            var ship = new AircraftCarrier();

            var res = boardGame.PlaceShipAtCoordinates(ship, A1Coordinate, A5Coordinate);

            Assert.True(res);
        }

        [Fact]
        public void PlaceShipAtCoordinates_AircraftCarrier_From_A5_Coordinates_To_A1_Coordinates_Should_Return_True()
        {
            BoardGame boardGame = new BoardGame();
            boardGame.InitBoardGame();
            var A1Coordinate = new BoardCoordinates(1, 1);
            var A5Coordinate = new BoardCoordinates(1, 5);
            var ship = new AircraftCarrier();

            var res = boardGame.PlaceShipAtCoordinates(ship, A5Coordinate, A1Coordinate);

            Assert.True(res);
        }


    }
}
