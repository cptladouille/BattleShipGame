using BatailleNavaleApp;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class BattleShipGameMenuTests
    {
        private readonly BattleShipGameMenu _menu;

        public BattleShipGameMenuTests()
        {
            _menu = new BattleShipGameMenu();
        }

        [Fact]
        public void GetMainMenu_void_Should_Return_string()
        {
            var res = BattleShipGameMenu.GetMainMenu();

            Assert.IsType<string>(res);
        }

        [Fact]
        public void GetMainMenu_void_Should_Return_string_Should_Equal_640_length()
        {
            var res = BattleShipGameMenu.GetMainMenu();

            Assert.True(res.Length == 640);
        }
        [Fact]
        public void GetPauseMenu_void_Should_Return_string()
        {
            var res = BattleShipGameMenu.GetPauseMenu();

            Assert.IsType<string>(res);
        }

        [Fact]
        public void GetPauseMenu_void_Should_Return_string_Should_Equal_477_length()
        {
            var res = BattleShipGameMenu.GetPauseMenu();

            Assert.True(res.Length == 477);
        }


    }
}
