using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTeamManagerApi.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsWon",
                table: "Matches",
                newName: "TeamScore");

            migrationBuilder.AddColumn<int>(
                name: "OpponentScore",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpponentScore",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "TeamScore",
                table: "Matches",
                newName: "IsWon");
        }
    }
}
