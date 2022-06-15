using System;
using Microsoft.EntityFrameworkCore.Migrations;
using testing.Models;

namespace testing.Migrations.Medical
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Allmeetings",
                newName: "allmeetings");

            migrationBuilder.RenameColumn(
                name: "doctor patronymic",
                table: "weekschedule",
                newName: "doc_patro");

            migrationBuilder.RenameColumn(
                name: "doctor lname",
                table: "weekschedule",
                newName: "doc_lname");

            migrationBuilder.RenameColumn(
                name: "doctor fname",
                table: "weekschedule",
                newName: "doc_fname");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "weekschedule",
                newName: "history_id");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "allmeetings",
                newName: "patronymic");

            migrationBuilder.RenameColumn(
                name: "MedcardId",
                table: "allmeetings",
                newName: "medcardid");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "allmeetings",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "allmeetings",
                newName: "info");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "allmeetings",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Diagnosis",
                table: "allmeetings",
                newName: "diagnosis");

            migrationBuilder.RenameColumn(
                name: "Depname",
                table: "allmeetings",
                newName: "depname");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "allmeetings",
                newName: "appointmentid");

            migrationBuilder.RenameColumn(
                name: "Appdate",
                table: "allmeetings",
                newName: "appdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                table: "weekschedule",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "app_id",
                table: "weekschedule",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dep_name",
                table: "weekschedule",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doc_id",
                table: "weekschedule",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Gender>(
                name: "gender",
                table: "weekschedule",
                type: "gender",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "p_birth",
                table: "weekschedule",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role_name",
                table: "weekschedule",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                table: "freeappointmentsweek",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doctor_id",
                table: "freeappointmentsweek",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "freeappointmentsweek",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "schedule_id",
                table: "freeappointmentsweek",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "familydoctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "confirmed",
                table: "declaration",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "d_id",
                table: "completedmeetings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "p_id",
                table: "completedmeetings",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "appointmentid",
                table: "allmeetings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "doc_id",
                table: "allmeetings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "real_app_id",
                table: "allmeetings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "activereferrals",
                columns: table => new
                {
                    declaration_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    issued_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "freepatients",
                columns: table => new
                {
                    p_id = table.Column<string>(type: "text", nullable: true),
                    p_fname = table.Column<string>(type: "text", nullable: true),
                    p_lname = table.Column<string>(type: "text", nullable: true),
                    p_patro = table.Column<string>(type: "text", nullable: true),
                    dateofbirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "medcard_manager_id_fkey",
                table: "medcard",
                column: "manager_id",
                principalTable: "manager",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "medcard_manager_id_fkey",
                table: "medcard");

            migrationBuilder.DropTable(
                name: "activereferrals");

            migrationBuilder.DropTable(
                name: "freepatients");

            migrationBuilder.DropColumn(
                name: "app_id",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "dep_name",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "doc_id",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "p_birth",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "role_name",
                table: "weekschedule");

            migrationBuilder.DropColumn(
                name: "doctor_id",
                table: "freeappointmentsweek");

            migrationBuilder.DropColumn(
                name: "id",
                table: "freeappointmentsweek");

            migrationBuilder.DropColumn(
                name: "schedule_id",
                table: "freeappointmentsweek");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "familydoctors");

            migrationBuilder.DropColumn(
                name: "confirmed",
                table: "declaration");

            migrationBuilder.DropColumn(
                name: "d_id",
                table: "completedmeetings");

            migrationBuilder.DropColumn(
                name: "p_id",
                table: "completedmeetings");

            migrationBuilder.DropColumn(
                name: "doc_id",
                table: "allmeetings");

            migrationBuilder.DropColumn(
                name: "real_app_id",
                table: "allmeetings");

            migrationBuilder.RenameTable(
                name: "allmeetings",
                newName: "Allmeetings");

            migrationBuilder.RenameColumn(
                name: "doc_patro",
                table: "weekschedule",
                newName: "doctor patronymic");

            migrationBuilder.RenameColumn(
                name: "doc_lname",
                table: "weekschedule",
                newName: "doctor lname");

            migrationBuilder.RenameColumn(
                name: "doc_fname",
                table: "weekschedule",
                newName: "doctor fname");

            migrationBuilder.RenameColumn(
                name: "history_id",
                table: "weekschedule",
                newName: "experience");

            migrationBuilder.RenameColumn(
                name: "patronymic",
                table: "Allmeetings",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "medcardid",
                table: "Allmeetings",
                newName: "MedcardId");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Allmeetings",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "info",
                table: "Allmeetings",
                newName: "Info");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Allmeetings",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "diagnosis",
                table: "Allmeetings",
                newName: "Diagnosis");

            migrationBuilder.RenameColumn(
                name: "depname",
                table: "Allmeetings",
                newName: "Depname");

            migrationBuilder.RenameColumn(
                name: "appointmentid",
                table: "Allmeetings",
                newName: "AppointmentId");

            migrationBuilder.RenameColumn(
                name: "appdate",
                table: "Allmeetings",
                newName: "Appdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                table: "weekschedule",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                table: "freeappointmentsweek",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Allmeetings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
