using BatailleNavaleApp.Entities;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class BoardCoordinatesTests
    {
        private readonly BoardCoordinates _boardCoordinates;

        public BoardCoordinatesTests()
        {
            _boardCoordinates = new BoardCoordinates();
        }

        [Fact]
        public void Coordinates_With_A1_Should_Return_A1()
        {
            BoardCoordinates boardCoordinates = new BoardCoordinates(1, 1);

            var res = boardCoordinates.Coordinates;

            Assert.Equal("A1", res);
        }

        [Fact]
        public void Parse_With_A_And_1_Should_Return_BoardCoordinates()
        {
            var input = "A1";

            var res = BoardCoordinates.Parse(input);

            Assert.IsType<BoardCoordinates>(res);
        }

        [Fact]
        public void Parse_With_A_And_1_Should_Return_A1_Coordinates()
        {
            var input = "A1";

            var res = BoardCoordinates.Parse(input);

            Assert.True(res.Coordinates == "A1");
        }

        [Fact]
        public void Parse_With_A_And_15_Should_Return_Null()
        {
            var input = "A15";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }
        [Fact]
        public void Parse_With_A_And_0_Should_Return_Null()
        {
            var input = "A0";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }

        [Fact]
        public void Parse_With_A_And_A_Should_Return_Null()
        {
            var input = "AA";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }
        [Fact]
        public void Parse_With_N_And_1_Should_Return_Null()
        {
            var input = "N1";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }
        [Fact]
        public void Parse_With_0_And_1_Should_Return_Null()
        {
            var input = "01";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }
        [Fact]
        public void Parse_With_A_Should_Return_Null()
        {
            var input = "A";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }

        [Fact]
        public void Parse_With_Void_Should_Return_Null()
        {
            var input = "";

            var res = BoardCoordinates.Parse(input);

            Assert.Null(res);
        }

    }
}
