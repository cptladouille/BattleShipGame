using BatailleNavaleApp;
using BatailleNavaleApp.Entities;
using System.Collections.Generic;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class BattleShipGameTests
    {
        private readonly BattleShipGame _battleShipGame;

        public BattleShipGameTests()
        {
            _battleShipGame = new BattleShipGame();
        }

        [Fact]
        public void ChooseFirstPlayer_With_Void_Should_Return_Player_Of_BattleShipGame()
        {
            BattleShipGame battleShipGame = new BattleShipGame
            {
                Player1 = new Player(),
                Player2 = new Player()
            };

            var res = battleShipGame.ChooseFirstPlayer();

            Assert.True(res == battleShipGame.Player1 || res == battleShipGame.Player2);
        }

        [Fact]
        public void ChooseFirstPlayer_With_Void_Should_Return_Player()
        {
            BattleShipGame battleShipGame = new BattleShipGame
            {
                Player1 = new Player(),
                Player2 = new Player()
            };

            var res = battleShipGame.ChooseFirstPlayer();

            Assert.IsType<Player>(res);
        }

        [Fact]
        public void IniPlayerShips_With_Void_Return_List_Of_Ships()
        {
            BattleShipGame battleShipGame = new BattleShipGame();

            var res = battleShipGame.InitPlayerShips();

            Assert.IsType<List<Ship>>(res);
        }
        [Fact]
        public void IniPlayerShips_With_Void_Return_List_Of_5_Ships()
        {
            BattleShipGame battleShipGame = new BattleShipGame();

            var res = battleShipGame.InitPlayerShips();

            Assert.True(res.Count == 5);
        }    }
}
