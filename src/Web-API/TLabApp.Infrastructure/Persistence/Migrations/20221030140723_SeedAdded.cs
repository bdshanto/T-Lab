using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TLabApp.Infrastructure.Persistence.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            AppDbContextInitializer.AuditAbleSeed();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
