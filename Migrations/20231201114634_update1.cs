using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlämningsuppgift_Databasutveckling.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfLoan",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "DateOfReturn",
                table: "Libraries");

            migrationBuilder.RenameColumn(
                name: "IsRented",
                table: "Libraries",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "DateOfLoan",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateOfReturn",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfLoan",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateOfReturn",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Libraries",
                newName: "IsRented");

            migrationBuilder.AddColumn<string>(
                name: "DateOfLoan",
                table: "Libraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateOfReturn",
                table: "Libraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
