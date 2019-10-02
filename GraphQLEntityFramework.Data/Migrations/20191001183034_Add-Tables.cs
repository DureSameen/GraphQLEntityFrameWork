using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLEntityFramework.Data.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Content", "Description", "Title", "Type" },
                values: new object[] { 1, "Today is the my day in the office", null, " A beautiful day start", 0 });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Content", "Description", "Title", "Type" },
                values: new object[] { 2, "My visit to expo center was so good", null, "Expo center visit", 1 });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "Content", "Description", "Title", "Type" },
                values: new object[] { 3, "It was so good and helpful in learning many new things", null, "Developer Conference 2019", 1 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BlogId", "Remarks", "UserName" },
                values: new object[] { 1, 2, "I was there too, it was a really nice event", null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BlogId", "Remarks", "UserName" },
                values: new object[] { 2, 2, "I missed it, better luck next time", null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BlogId", "Remarks", "UserName" },
                values: new object[] { 3, 3, "Anyone can help me with schedule on next conference", null });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BlogId",
                table: "Reviews",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
