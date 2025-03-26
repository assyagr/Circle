using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class CircleF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CircleFriendships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SentToId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CircleUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CircleUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CircleUserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleFriendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleFriendships_AspNetUsers_CircleUserId",
                        column: x => x.CircleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleFriendships_AspNetUsers_CircleUserId1",
                        column: x => x.CircleUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleFriendships_AspNetUsers_CircleUserId2",
                        column: x => x.CircleUserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleFriendships_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CircleFriendships_AspNetUsers_SentToId",
                        column: x => x.SentToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircleFriendships_CircleUserId",
                table: "CircleFriendships",
                column: "CircleUserId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircleFriendships");
        }
    }
}
