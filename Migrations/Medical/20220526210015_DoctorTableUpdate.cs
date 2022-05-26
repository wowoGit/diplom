using Microsoft.EntityFrameworkCore.Migrations;
using testing.Models;

namespace testing.Migrations.Medical
{
    public partial class DoctorTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Gender>(
                name: "gender",
                table: "doctor",
                type: "gender",
                nullable: false,
                defaultValue: Gender.male);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "gender",
                table: "doctor");
        }
    }
}
