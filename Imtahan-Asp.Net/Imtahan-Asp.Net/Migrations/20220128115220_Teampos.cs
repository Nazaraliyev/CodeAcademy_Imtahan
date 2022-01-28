using Microsoft.EntityFrameworkCore.Migrations;

namespace Imtahan_Asp.Net.Migrations
{
    public partial class Teampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamPositionId",
                table: "teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "teamPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamPositions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teams_TeamPositionId",
                table: "teams",
                column: "TeamPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_teams_teamPositions_TeamPositionId",
                table: "teams",
                column: "TeamPositionId",
                principalTable: "teamPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teams_teamPositions_TeamPositionId",
                table: "teams");

            migrationBuilder.DropTable(
                name: "teamPositions");

            migrationBuilder.DropIndex(
                name: "IX_teams_TeamPositionId",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "TeamPositionId",
                table: "teams");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "teams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "teams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
