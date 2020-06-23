using Microsoft.EntityFrameworkCore.Migrations;

namespace DockerTest3.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HtmlWord",
                columns: table => new
                {
                    SaltedHash = table.Column<string>(nullable: false),
                    Word = table.Column<string>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    Salt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlWord", x => x.SaltedHash);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlWord");
        }
    }
}
