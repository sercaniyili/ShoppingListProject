using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teleperformance.Bootcamp.Persistence.Migrations
{
    public partial class relationseditlast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingLists_ShoppingListId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId1",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_AppUserId1",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingListId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ShoppingListId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_AppUserId",
                table: "ShoppingLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingListId",
                table: "Products",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingLists_ShoppingListId",
                table: "Products",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId",
                table: "ShoppingLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingLists_ShoppingListId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_AppUserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingListId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingListId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId1",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_AppUserId1",
                table: "ShoppingLists",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingListId1",
                table: "Products",
                column: "ShoppingListId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingLists_ShoppingListId1",
                table: "Products",
                column: "ShoppingListId1",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId1",
                table: "ShoppingLists",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
