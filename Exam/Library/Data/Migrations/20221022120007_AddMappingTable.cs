using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class AddMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserBook_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserBook_Books_BookId",
                table: "ApplicationUserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserBook",
                table: "ApplicationUserBook");

            migrationBuilder.RenameTable(
                name: "ApplicationUserBook",
                newName: "ApplicationUsersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserBook_ApplicationUserId",
                table: "ApplicationUsersBooks",
                newName: "IX_ApplicationUsersBooks_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersBooks",
                table: "ApplicationUsersBooks",
                columns: new[] { "BookId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersBooks_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersBooks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersBooks_Books_BookId",
                table: "ApplicationUsersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersBooks_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersBooks_Books_BookId",
                table: "ApplicationUsersBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersBooks",
                table: "ApplicationUsersBooks");

            migrationBuilder.RenameTable(
                name: "ApplicationUsersBooks",
                newName: "ApplicationUserBook");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersBooks_ApplicationUserId",
                table: "ApplicationUserBook",
                newName: "IX_ApplicationUserBook_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserBook",
                table: "ApplicationUserBook",
                columns: new[] { "BookId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserBook_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserBook",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserBook_Books_BookId",
                table: "ApplicationUserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
