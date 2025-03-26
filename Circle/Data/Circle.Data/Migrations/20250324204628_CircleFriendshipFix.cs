using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class CircleFriendshipFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleFriendships_AspNetUsers_CircleUserId1",
                table: "CircleFriendships");

            migrationBuilder.DropForeignKey(
                name: "FK_CircleFriendships_AspNetUsers_CircleUserId2",
                table: "CircleFriendships");

            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_CircleUserId1",
                table: "CircleFriendships");

            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_CircleUserId2",
                table: "CircleFriendships");

            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_CreatedById",
                table: "CircleFriendships");

            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_SentToId",
                table: "CircleFriendships");

            migrationBuilder.DropColumn(
                name: "CircleUserId1",
                table: "CircleFriendships");

            migrationBuilder.DropColumn(
                name: "CircleUserId2",
                table: "CircleFriendships");

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_CreatedById",
                table: "CircleFriendships",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_SentToId",
                table: "CircleFriendships",
                column: "SentToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_CreatedById",
                table: "CircleFriendships");

            migrationBuilder.DropIndex(
                name: "IX_CircleFriendships_SentToId",
                table: "CircleFriendships");

            migrationBuilder.AddColumn<string>(
                name: "CircleUserId1",
                table: "CircleFriendships",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CircleUserId2",
                table: "CircleFriendships",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_CircleUserId1",
                table: "CircleFriendships",
                column: "CircleUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_CircleUserId2",
                table: "CircleFriendships",
                column: "CircleUserId2");

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_CreatedById",
                table: "CircleFriendships",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_SentToId",
                table: "CircleFriendships",
                column: "SentToId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CircleFriendships_AspNetUsers_CircleUserId1",
                table: "CircleFriendships",
                column: "CircleUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CircleFriendships_AspNetUsers_CircleUserId2",
                table: "CircleFriendships",
                column: "CircleUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
