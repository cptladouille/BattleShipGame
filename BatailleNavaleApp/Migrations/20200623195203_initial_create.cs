using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BatailleNavaleApp.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardCoordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardCoordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PersonnalBoardGameId = table.Column<Guid>(nullable: true),
                    EnnemyBoardGameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_BoardGames_EnnemyBoardGameId",
                        column: x => x.EnnemyBoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_BoardGames_PersonnalBoardGameId",
                        column: x => x.PersonnalBoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BattleShipGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Player1Id = table.Column<Guid>(nullable: true),
                    Player2Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleShipGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleShipGames_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BattleShipGames_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    ShipType = table.Column<int>(nullable: false),
                    Damages = table.Column<int>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardCells",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BoardCoordinatesId = table.Column<Guid>(nullable: true),
                    CellOccupant = table.Column<int>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: true),
                    ShipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardCells_BoardCoordinates_BoardCoordinatesId",
                        column: x => x.BoardCoordinatesId,
                        principalTable: "BoardCoordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardCells_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardCells_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleShipGames_Player1Id",
                table: "BattleShipGames",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BattleShipGames_Player2Id",
                table: "BattleShipGames",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BoardCells_BoardCoordinatesId",
                table: "BoardCells",
                column: "BoardCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardCells_BoardGameId",
                table: "BoardCells",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardCells_ShipId",
                table: "BoardCells",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_EnnemyBoardGameId",
                table: "Players",
                column: "EnnemyBoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonnalBoardGameId",
                table: "Players",
                column: "PersonnalBoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PlayerId",
                table: "Ships",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleShipGames");

            migrationBuilder.DropTable(
                name: "BoardCells");

            migrationBuilder.DropTable(
                name: "BoardCoordinates");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "BoardGames");
        }
    }
}
