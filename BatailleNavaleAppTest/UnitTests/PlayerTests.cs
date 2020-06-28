using BatailleNavaleApp;
using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class PlayerTests
    {
        private readonly Player _player;

        public PlayerTests()
        {
            _player = new Player();
        }

        [Fact]
        public void ResetGameBoards_Should_Have_Not_Null_PersonnalBoardGame()
        {
            Player player = new Player();

            player.ResetGameBoards();

            Assert.NotNull(player.PersonnalBoardGame);
        }
        [Fact]
        public void ResetGameBoards_Should_Have_Not_Null_EnnemyBoardGame()
        {
            Player player = new Player();

            player.ResetGameBoards();

            Assert.NotNull(player.EnnemyBoardGame);
        }
        [Fact]
        public void CheckFireCoordinates_At_UnShooted_A1_Coordinates_Should_Return_A1_Coordinates()
        {
            Player player = new Player();
            BoardCoordinates testCoordinates = new BoardCoordinates(1, 1);

            var res = player.CheckFireCoordinates(testCoordinates);

            Assert.True(res.Equals(testCoordinates));
        }

        [Fact]
        public void CheckFireCoordinates_At_HITTED_A1_Coordinates_Should_Return_Null()
        {
            Player player = new Player();
            BoardCoordinates testCoordinates = new BoardCoordinates(1, 1);
            var occupedCell = player.EnnemyBoardGame.Cells.First(cell => cell.BoardCoordinates.Coordinates == testCoordinates.Coordinates);
            occupedCell.CellOccupant = ShipType.HITTED;

            var res = player.CheckFireCoordinates(testCoordinates);

            Assert.Null(res);
        }

        [Fact]
        public void CheckFireCoordinates_At_MISSED_A1_Coordinates_Should_Return_Null()
        {
            Player player = new Player();
            BoardCoordinates testCoordinates = new BoardCoordinates(1, 1);
            var occupedCell = player.EnnemyBoardGame.Cells.First(cell => cell.BoardCoordinates.Coordinates == testCoordinates.Coordinates);
            occupedCell.CellOccupant = ShipType.MISSED;

            var res = player.CheckFireCoordinates(testCoordinates);

            Assert.Null(res);
        }

        [Fact]
        public void ReactToShot_At_Occuped_A1_Coordinates_Should_Return_HITTED()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            var A1Cell = player.PersonnalBoardGame.Cells.First(cell => cell.BoardCoordinates.Coordinates == A1Coordinates.Coordinates);
            player.Ships.Add(new TorpedoBoat() { OccupedCells = new List<BoardCell>() { A1Cell } });
            A1Cell.CellOccupant = ShipType.TORPEDO_BOAT;

            var res = player.ReactToShot(A1Coordinates);

            Assert.True(res == ShipType.HITTED);
        }

        [Fact]
        public void ReactToShot_At_Unoccuped_A1_Coordinates_Should_Return_MISSED()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);

            var res = player.ReactToShot(A1Coordinates);

            Assert.True(res == ShipType.MISSED);
        }

        [Fact]
        public void BuildGameBoard_void_Should_Return_string()
        {
            Player player = new Player();

            var res = player.BuildGameBoard();

            Assert.IsType<string>(res);
        }

        [Fact]
        public void BuildGameBoard_void_Should_Return_string_with_length_greater_than_800()
        {
            Player player = new Player();

            var res = player.BuildGameBoard();

            Assert.True(res.Length > 800);
        }


        [Fact]
        public void UpdateBoardWithShotResult_HITTED_At_A1_Coordinates_Should_Set_EnnemyBoard_At_A1_Coordinate_HITTED
()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            var shotResult = ShipType.HITTED;

            player.UpdateBoardWithShotResult(shotResult, A1Coordinates);

            Assert.True(player.EnnemyBoardGame.Cells.At(A1Coordinates).CellOccupant == shotResult);
        }

        [Fact]
        public void UpdateBoardWithShotResult_MISSED_At_A1_Coordinates_Should_Set_EnnemyBoard_At_A1_Coordinate_MISSED()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            var shotResult = ShipType.MISSED;

            player.UpdateBoardWithShotResult(shotResult, A1Coordinates);

            Assert.True(player.EnnemyBoardGame.Cells.At(A1Coordinates).CellOccupant == shotResult);
        }


        [Fact]
        public void PlaceShip_CounterTorpedo_From_Unoccuped_A1_Coordinates_To_Unoccuped_A3_Coordinates_Should_Return_True()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            BoardCoordinates A3Coordinates = new BoardCoordinates(1, 3);
            var ship = new CounterTorpedo();

            var res = player.PlaceShip(ship, A1Coordinates, A3Coordinates);

            Assert.True(res);
        }
        [Fact]
        public void PlaceShip_CounterTorpedo_From_Occuped_A1_Coordinates_To_Unoccuped_A3_Coordinates_Should_Return_True()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            BoardCoordinates A3Coordinates = new BoardCoordinates(1, 3);
            var A1Cell = player.PersonnalBoardGame.Cells.First(cell => cell.BoardCoordinates.Coordinates == A1Coordinates.Coordinates);
            A1Cell.CellOccupant = ShipType.AICRAFT_CARRIER;
            var ship = new CounterTorpedo();

            var res = player.PlaceShip(ship, A1Coordinates, A3Coordinates);

            Assert.False(res);
        }

        [Fact]
        public void PlaceShip_CounterTorpedo_From_Unoccuped_A1_Coordinates_To_Occuped_A3_Coordinates_Should_Return_True()
        {
            Player player = new Player();
            BoardCoordinates A1Coordinates = new BoardCoordinates(1, 1);
            BoardCoordinates A3Coordinates = new BoardCoordinates(1, 3);
            var A3Cell = player.PersonnalBoardGame.Cells.First(cell => cell.BoardCoordinates.Coordinates == A3Coordinates.Coordinates);
            A3Cell.CellOccupant = ShipType.AICRAFT_CARRIER;
            var ship = new CounterTorpedo();

            var res = player.PlaceShip(ship, A1Coordinates, A3Coordinates);

            Assert.False(res);
        }

        [Fact]
        public void LostGame_With_Destroyed_Ship_Should_Return_True()
        {
            Player player = new Player();
            var ship = new CounterTorpedo() { Damages = 3 };
            player.Ships.Add(ship);

            var res = player.LostGame;

            Assert.True(res);
        }
        [Fact]
        public void LostGame_With_Intact_Ship_Should_Return_False()
        {
            Player player = new Player();
            var ship = new CounterTorpedo();
            player.Ships.Add(ship);

            var res = player.LostGame;

            Assert.False(res);
        }

        [Fact]
        public void Player_With_Name_Should_Have_Name()
        {
            Player player = new Player("test");

            var res = player.Name;

            Assert.Equal("test",res);
        }

    }
}
