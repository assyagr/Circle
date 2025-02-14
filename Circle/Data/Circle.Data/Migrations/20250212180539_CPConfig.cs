using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Circle.Data.Migrations
{
    /// <inheritdoc />
    public partial class CPConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_CirclePostId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CirclePostId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CirclePostId",
                table: "Attachments");

            migrationBuilder.CreateTable(
                name: "AttachmentCirclePost",
                columns: table => new
                {
                    CirclePostId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentCirclePost", x => new { x.CirclePostId, x.ContentId });
                    table.ForeignKey(
                        name: "FK_AttachmentCirclePost_Attachments_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentCirclePost_Posts_CirclePostId",
                        column: x => x.CirclePostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentCirclePost_ContentId",
                table: "AttachmentCirclePost",
                column: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentCirclePost");

            migrationBuilder.AddColumn<string>(
                name: "CirclePostId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CirclePostId",
                table: "Attachments",
                column: "CirclePostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Posts_CirclePostId",
                table: "Attachments",
                column: "CirclePostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
