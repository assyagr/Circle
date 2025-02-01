using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachments_ProfilePictureCloudUrlId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CirclePostCircleUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfilePictureCloudUrlId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CricleRole",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureCloudUrlId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TypeOfAurdiance",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CirclePostId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CircleRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CirclePostId",
                table: "AspNetUsers",
                column: "CirclePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_CirclePostId",
                table: "AspNetUsers",
                column: "CirclePostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CircleRole",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CricleRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureCloudUrlId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfAurdiance",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CirclePostCircleUser",
                columns: table => new
                {
                    PostsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaggedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirclePostCircleUser", x => new { x.PostsId, x.TaggedUsersId });
                    table.ForeignKey(
                        name: "FK_CirclePostCircleUser_AspNetUsers_TaggedUsersId",
                        column: x => x.TaggedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CirclePostCircleUser_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfilePictureCloudUrlId",
                table: "AspNetUsers",
                column: "ProfilePictureCloudUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_CirclePostCircleUser_TaggedUsersId",
                table: "CirclePostCircleUser",
                column: "TaggedUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachments_ProfilePictureCloudUrlId",
                table: "AspNetUsers",
                column: "ProfilePictureCloudUrlId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
