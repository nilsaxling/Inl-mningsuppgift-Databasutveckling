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
            migrationBuilder.DropTable(
                name: "CustomerLibrary");

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LibraryId",
                table: "Customers",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CustomerId",
                table: "Books",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Customers_CustomerId",
                table: "Books",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Libraries_LibraryId",
                table: "Customers",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Customers_CustomerId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Libraries_LibraryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LibraryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Books_CustomerId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "CustomerLibrary",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    LibrariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLibrary", x => new { x.CustomersCustomerId, x.LibrariesId });
                    table.ForeignKey(
                        name: "FK_CustomerLibrary_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerLibrary_Libraries_LibrariesId",
                        column: x => x.LibrariesId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLibrary_LibrariesId",
                table: "CustomerLibrary",
                column: "LibrariesId");
        }
    }
}
