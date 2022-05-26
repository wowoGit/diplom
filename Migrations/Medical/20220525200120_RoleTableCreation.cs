using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace testing.Migrations.Medical
{
    public partial class RoleTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "roleId",
                table: "doctor",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(name: "id",type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(name: "name",type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctor_RoleId1",
                table: "doctor",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_Role_RoleId1",
                table: "doctor",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctor_Role_RoleId1",
                table: "doctor");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_doctor_RoleId1",
                table: "doctor");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "doctor");
        }
    }
}
