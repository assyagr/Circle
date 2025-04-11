using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class FollowingSettingReletionship1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserCircleUser_AspNetUsers_FollowersId",
                table: "CircleUserCircleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserCircleUser_AspNetUsers_FollowingId",
                table: "CircleUserCircleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CircleUserCircleUser",
                table: "CircleUserCircleUser");

            migrationBuilder.RenameTable(
                name: "CircleUserCircleUser",
                newName: "UserFollows");

            migrationBuilder.RenameIndex(
                name: "IX_CircleUserCircleUser_FollowingId",
                table: "UserFollows",
                newName: "IX_UserFollows_FollowingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows",
                columns: new[] { "FollowersId", "FollowingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_AspNetUsers_FollowersId",
                table: "UserFollows",
                column: "FollowersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_AspNetUsers_FollowingId",
                table: "UserFollows",
                column: "FollowingId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_AspNetUsers_FollowersId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_AspNetUsers_FollowingId",
                table: "UserFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows");

            migrationBuilder.RenameTable(
                name: "UserFollows",
                newName: "CircleUserCircleUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_FollowingId",
                table: "CircleUserCircleUser",
                newName: "IX_CircleUserCircleUser_FollowingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CircleUserCircleUser",
                table: "CircleUserCircleUser",
                columns: new[] { "FollowersId", "FollowingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserCircleUser_AspNetUsers_FollowersId",
                table: "CircleUserCircleUser",
                column: "FollowersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserCircleUser_AspNetUsers_FollowingId",
                table: "CircleUserCircleUser",
                column: "FollowingId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
