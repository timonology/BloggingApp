using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggingApp.Persistence.Migrations
{
    public partial class AddOtherBlogPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherBlogPlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endpoint = table.Column<string>(nullable: true),
                    HasAuthentication = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherBlogPlatforms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherBlogPlatforms");
        }
    }
}
