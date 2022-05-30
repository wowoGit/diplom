using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testing.Migrations.Medical
{
    public partial class wtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "proc_result",
                table: "completedmeetings",
                newName: "Proc_result");

            migrationBuilder.RenameColumn(
                name: "patronymic",
                table: "completedmeetings",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "completedmeetings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dose",
                table: "completedmeetings",
                newName: "Dose");

            migrationBuilder.RenameColumn(
                name: "d_patro",
                table: "completedmeetings",
                newName: "D_patro");

            migrationBuilder.RenameColumn(
                name: "d_lname",
                table: "completedmeetings",
                newName: "D_lname");

            migrationBuilder.RenameColumn(
                name: "d_fname",
                table: "completedmeetings",
                newName: "D_fname");

            migrationBuilder.RenameColumn(
                name: "app_info",
                table: "completedmeetings",
                newName: "App_info");

            migrationBuilder.RenameColumn(
                name: "appdate",
                table: "completedmeetings",
                newName: "App_date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "historydocument",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "historydocument",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dose",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateo",
                table: "completedmeetings",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datec",
                table: "completedmeetings",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "D_patro",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "D_lname",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "D_fname",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "App_info",
                table: "completedmeetings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proc_result",
                table: "completedmeetings",
                newName: "proc_result");

            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "completedmeetings",
                newName: "patronymic");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "completedmeetings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Dose",
                table: "completedmeetings",
                newName: "dose");

            migrationBuilder.RenameColumn(
                name: "D_patro",
                table: "completedmeetings",
                newName: "d_patro");

            migrationBuilder.RenameColumn(
                name: "D_lname",
                table: "completedmeetings",
                newName: "d_lname");

            migrationBuilder.RenameColumn(
                name: "D_fname",
                table: "completedmeetings",
                newName: "d_fname");

            migrationBuilder.RenameColumn(
                name: "App_info",
                table: "completedmeetings",
                newName: "app_info");

            migrationBuilder.RenameColumn(
                name: "App_date",
                table: "completedmeetings",
                newName: "appdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "historydocument",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "historydocument",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateo",
                table: "completedmeetings",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datec",
                table: "completedmeetings",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "patronymic",
                table: "completedmeetings",
                type: "character varying(100)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dose",
                table: "completedmeetings",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "d_patro",
                table: "completedmeetings",
                type: "character varying(100)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "d_lname",
                table: "completedmeetings",
                type: "character varying(100)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "d_fname",
                table: "completedmeetings",
                type: "character varying(100)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "app_info",
                table: "completedmeetings",
                type: "character varying(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
