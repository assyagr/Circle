using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Hashtags_Posts_CirclePostId",
                table: "Hashtags");

            migrationBuilder.DropIndex(
                name: "IX_Hashtags_CirclePostId",
                table: "Hashtags");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CirclePostId",
                table: "Hashtags");

            migrationBuilder.DropColumn(
                name: "CirclePostId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Hashtags",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CirclePostCircleUser",
                columns: table => new
                {
                    CirclePostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaggedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirclePostCircleUser", x => new { x.CirclePostId, x.TaggedUsersId });
                    table.ForeignKey(
                        name: "FK_CirclePostCircleUser_AspNetUsers_TaggedUsersId",
                        column: x => x.TaggedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CirclePostCircleUser_Posts_CirclePostId",
                        column: x => x.CirclePostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CirclePostHashtag",
                columns: table => new
                {
                    CirclePostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashtagsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirclePostHashtag", x => new { x.CirclePostId, x.HashtagsId });
                    table.ForeignKey(
                        name: "FK_CirclePostHashtag_Hashtags_HashtagsId",
                        column: x => x.HashtagsId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CirclePostHashtag_Posts_CirclePostId",
                        column: x => x.CirclePostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CirclePostCircleUser_TaggedUsersId",
                table: "CirclePostCircleUser",
                column: "TaggedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CirclePostHashtag_HashtagsId",
                table: "CirclePostHashtag",
                column: "HashtagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CirclePostCircleUser");

            migrationBuilder.DropTable(
                name: "CirclePostHashtag");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Hashtags",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CirclePostId",
                table: "Hashtags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CirclePostId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_CirclePostId",
                table: "Hashtags",
                column: "CirclePostId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Hashtags_Posts_CirclePostId",
                table: "Hashtags",
                column: "CirclePostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
