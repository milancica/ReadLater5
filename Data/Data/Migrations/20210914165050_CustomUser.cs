using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Categories_CategoryId",
                table: "Bookmark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark");

            migrationBuilder.RenameTable(
                name: "Bookmark",
                newName: "Bookmarks");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_CategoryId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Bookmarks",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Bookmarks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_ApplicationUserId",
                table: "Bookmarks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId",
                table: "Bookmarks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_AspNetUsers_ApplicationUserId",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Categories_CategoryId",
                table: "Bookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_ApplicationUserId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Bookmarks");

            migrationBuilder.RenameTable(
                name: "Bookmarks",
                newName: "Bookmark");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_CategoryId",
                table: "Bookmark",
                newName: "IX_Bookmark_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "Bookmark",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Bookmark",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmark",
                table: "Bookmark",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Categories_CategoryId",
                table: "Bookmark",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
