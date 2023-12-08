using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlämningsuppgift_Databasutveckling.Migrations
{
    /// <inheritdoc />
    public partial class loanNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "LoanID",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books",
                column: "LoanID",
                principalTable: "Loans",
                principalColumn: "LoanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "LoanID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Loans_LoanID",
                table: "Books",
                column: "LoanID",
                principalTable: "Loans",
                principalColumn: "LoanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
