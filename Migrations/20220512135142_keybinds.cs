using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace temp.Migrations
{
    public partial class PatientBind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserId",
                table: "patient",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "user_id",
                table: "patient",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "doctor",
                column: "user_id");
                
            migrationBuilder.AddForeignKey(
                name: "user_id",
                table: "doctor",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "manager",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "user_id",
                table: "manager",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
