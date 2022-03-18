using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceManagementSystem.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Items",
                table: "tbl_Items");

            migrationBuilder.RenameTable(
                name: "tbl_Items",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "tbl_Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Items",
                table: "tbl_Items",
                column: "ID");
        }
    }
}
