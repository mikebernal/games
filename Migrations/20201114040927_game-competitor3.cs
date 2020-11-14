using Microsoft.EntityFrameworkCore.Migrations;

namespace games.Migrations
{
    public partial class gamecompetitor3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Competitors_CompetitorId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CompetitorId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CompetitorId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "CompetitorGame",
                columns: table => new
                {
                    CompetitorsId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitorGame", x => new { x.CompetitorsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CompetitorGame_Competitors_CompetitorsId",
                        column: x => x.CompetitorsId,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitorGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitorGame_GamesId",
                table: "CompetitorGame",
                column: "GamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitorGame");

            migrationBuilder.AddColumn<int>(
                name: "CompetitorId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompetitorId",
                table: "Games",
                column: "CompetitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Competitors_CompetitorId",
                table: "Games",
                column: "CompetitorId",
                principalTable: "Competitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
