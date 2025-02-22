using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class Friendships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CircleUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentToId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircleUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CircleUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CircleUserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_CircleUserId",
                        column: x => x.CircleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_CircleUserId1",
                        column: x => x.CircleUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_CircleUserId2",
                        column: x => x.CircleUserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CircleUserId",
                table: "AspNetUsers",
                column: "CircleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_CircleUserId",
                table: "Friendships",
                column: "CircleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_CircleUserId1",
                table: "Friendships",
                column: "CircleUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_CircleUserId2",
                table: "Friendships",
                column: "CircleUserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CircleUserId",
                table: "AspNetUsers",
                column: "CircleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CircleUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CircleUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CircleUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
