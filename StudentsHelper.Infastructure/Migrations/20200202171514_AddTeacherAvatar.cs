using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsHelper.Infastructure.Migrations
{
    public partial class AddTeacherAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Teachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Teachers");
        }
    }
}
