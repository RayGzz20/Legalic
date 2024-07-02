using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerApi.Migrations
{
    public partial class AddSpecialtiesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("Migrations", "Scripts", "AddSpecialtiesSeedData.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Specialties WHERE Id IN (1, 2, 3, 4);");
        }
    }
}
