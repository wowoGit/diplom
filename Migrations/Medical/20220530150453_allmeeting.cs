using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testing.Migrations.Medical
{
    public partial class allmeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allmeetings",
                columns: table => new
                {
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "text", nullable: true),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    MedcardId = table.Column<string>(type: "text", nullable: true),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    Depname = table.Column<string>(type: "text", nullable: true),
                    Appdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allmeetings");
        }
    }
}
