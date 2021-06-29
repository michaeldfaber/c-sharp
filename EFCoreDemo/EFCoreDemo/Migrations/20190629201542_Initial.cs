using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDemo.Migrations
{
    /// <summary>
    /// This was generated using the command "Add-Migration Initial -context LocalDbContext -o Migrations
    /// -o Migrations tells EF Core to put the migration file in the Migrations folder. I haven't found a
    /// way to configure this automatically (a default folder)
    /// </summary>
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "efcoredemo");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "efcoredemo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "efcoredemo");
        }
    }
}
