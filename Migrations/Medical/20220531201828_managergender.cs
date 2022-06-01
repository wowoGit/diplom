using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using testing.Models;

namespace testing.Migrations.Medical
{
    public partial class managergender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:bloodtype", "ZERO_plus,ZERO_minus,A_plus,A_minus,B_plus,B_minus,AB_plus,AB_minus")
                .Annotation("Npgsql:Enum:gender", "male,female");

            migrationBuilder.CreateTable(
                name: "allmeetings",
                columns: table => new
                {
                    diagnosis = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    patronymic = table.Column<string>(type: "text", nullable: true),
                    medcardid = table.Column<string>(type: "text", nullable: true),
                    appointmentid = table.Column<int>(type: "integer", nullable: true),
                    depname = table.Column<string>(type: "text", nullable: true),
                    appdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "completedmeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    fname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    diag = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    doc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    dateo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    datec = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    App_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    App_info = table.Column<string>(type: "text", nullable: true),
                    D_fname = table.Column<string>(type: "text", nullable: true),
                    D_lname = table.Column<string>(type: "text", nullable: true),
                    D_patro = table.Column<string>(type: "text", nullable: true),
                    pname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Proc_result = table.Column<string>(type: "text", nullable: true),
                    dateop = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Dose = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"Department_id_seq\"'::regclass)"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    floor = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctorsperdep",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    doctorsindepartment = table.Column<long>(name: "doctors in department", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "familydoctors",
                columns: table => new
                {
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    experience = table.Column<int>(type: "integer", nullable: true),
                    totalpatients = table.Column<long>(name: "total patients", type: "bigint", nullable: true),
                    patientfname = table.Column<string>(name: "patient fname", type: "character varying(50)", maxLength: 50, nullable: true),
                    patientlname = table.Column<string>(name: "patient lname", type: "character varying(50)", maxLength: 50, nullable: true),
                    patientpatro = table.Column<string>(name: "patient patro", type: "character varying(50)", maxLength: 50, nullable: true),
                    sign_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "freeappointmentsweek",
                columns: table => new
                {
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    cabinet = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    employment_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("manager_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "medication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    sign_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    gender = table.Column<Gender>(type: "gender", nullable: false),
                    blood_type = table.Column<BloodType>(type: "public.bloodtype", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("patient_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "patientinfo",
                columns: table => new
                {
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    familydoctorfname = table.Column<string>(name: "family doctor fname", type: "character varying(50)", maxLength: 50, nullable: true),
                    familydoctorlname = table.Column<string>(name: "family doctor lname", type: "character varying(50)", maxLength: 50, nullable: true),
                    familydoctorpatro = table.Column<string>(name: "family doctor patro", type: "character varying(50)", maxLength: 50, nullable: true),
                    sign_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "procedure",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weekschedule",
                columns: table => new
                {
                    doctorfname = table.Column<string>(name: "doctor fname", type: "character varying(50)", maxLength: 50, nullable: true),
                    doctorlname = table.Column<string>(name: "doctor lname", type: "character varying(50)", maxLength: 50, nullable: true),
                    doctorpatronymic = table.Column<string>(name: "doctor patronymic", type: "character varying(50)", maxLength: 50, nullable: true),
                    experience = table.Column<int>(type: "integer", nullable: true),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    info = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    referral_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medcard",
                columns: table => new
                {
                    patient_id = table.Column<string>(type: "text", nullable: false),
                    manager_id = table.Column<string>(type: "text", nullable: false),
                    issued_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expired_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("medcard_pkey", x => x.patient_id);
                    table.ForeignKey(
                        name: "medcard_patient_id_fkey",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    employment_date = table.Column<DateTime>(type: "date", nullable: false),
                    experience = table.Column<int>(type: "integer", nullable: false),
                    about = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    cabinet = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<Gender>(type: "gender", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctor_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "doctor_department_id_fkey",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_doctor_Role_RoleId1",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "declaration",
                columns: table => new
                {
                    medcard_id = table.Column<string>(type: "text", nullable: false),
                    doctor_id = table.Column<string>(type: "text", nullable: false),
                    sign_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("declaration_pkey", x => x.medcard_id);
                    table.ForeignKey(
                        name: "declaration_doctor_id_fkey",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "declaration_medcard_id_fkey",
                        column: x => x.medcard_id,
                        principalTable: "medcard",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "headdepartment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_headdepartment", x => x.id);
                    table.ForeignKey(
                        name: "headdepartment_doctor_id_fkey",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_id = table.Column<string>(type: "text", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.id);
                    table.ForeignKey(
                        name: "schedule_doctor_id_fkey",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "referral",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    declaration_id = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    issued_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referral", x => x.id);
                    table.ForeignKey(
                        name: "referral_declaration_id_fkey",
                        column: x => x.declaration_id,
                        principalTable: "declaration",
                        principalColumn: "medcard_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "referral_department_id_fkey",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('appoitment_id_seq'::regclass)"),
                    medcard_id = table.Column<string>(type: "text", nullable: false),
                    schedule_id = table.Column<int>(type: "integer", nullable: false),
                    info = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    referral_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "appoitment_medcard_id_fkey",
                        column: x => x.medcard_id,
                        principalTable: "medcard",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "appoitment_referral_id_fkey",
                        column: x => x.referral_id,
                        principalTable: "referral",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "appoitment_schedule_id_fkey",
                        column: x => x.schedule_id,
                        principalTable: "schedule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    diagnosis = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("History_pkey", x => x.appointment_id);
                    table.ForeignKey(
                        name: "history_appointment_id_fkey",
                        column: x => x.appointment_id,
                        principalTable: "appointment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historydocument",
                columns: table => new
                {
                    history_id = table.Column<int>(type: "integer", nullable: false),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("historydocument_pkey", x => new { x.history_id, x.document_id });
                    table.ForeignKey(
                        name: "historydocument_document_id_fkey",
                        column: x => x.document_id,
                        principalTable: "document",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "historydocument_history_id_fkey",
                        column: x => x.history_id,
                        principalTable: "history",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historymedication",
                columns: table => new
                {
                    history_id = table.Column<int>(type: "integer", nullable: false),
                    medication_id = table.Column<int>(type: "integer", nullable: false),
                    dose = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("historymedication_pkey", x => new { x.history_id, x.medication_id });
                    table.ForeignKey(
                        name: "historymedication_history_id_fkey",
                        column: x => x.history_id,
                        principalTable: "history",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "historymedication_medication_id_fkey",
                        column: x => x.medication_id,
                        principalTable: "medication",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historyprocedure",
                columns: table => new
                {
                    history_id = table.Column<int>(type: "integer", nullable: false),
                    procedure_id = table.Column<int>(type: "integer", nullable: false),
                    result = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("historyprocedure_pkey", x => new { x.history_id, x.procedure_id });
                    table.ForeignKey(
                        name: "historyprocedure_history_id_fkey",
                        column: x => x.history_id,
                        principalTable: "history",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "historyprocedure_procedure_id_fkey",
                        column: x => x.procedure_id,
                        principalTable: "procedure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appoitment_medcard_id",
                table: "appointment",
                column: "medcard_id");

            migrationBuilder.CreateIndex(
                name: "IX_appoitment_referral_id",
                table: "appointment",
                column: "referral_id");

            migrationBuilder.CreateIndex(
                name: "IX_appoitment_schedule_id",
                table: "appointment",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_declaration_doctor_id",
                table: "declaration",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_department_id",
                table: "doctor",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_role_id",
                table: "doctor",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_headdepartment_doctor_id",
                table: "headdepartment",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_historydocument_document_id",
                table: "historydocument",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_historymedication_medication_id",
                table: "historymedication",
                column: "medication_id");

            migrationBuilder.CreateIndex(
                name: "IX_historyprocedure_procedure_id",
                table: "historyprocedure",
                column: "procedure_id");

            migrationBuilder.CreateIndex(
                name: "IX_medcard_manager_id",
                table: "medcard",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "medcard_patient_id_patient_id1_key",
                table: "medcard",
                column: "patient_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "patient",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_referral_department_id",
                table: "referral",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_referral_medcard_id",
                table: "referral",
                column: "declaration_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_doctor_id",
                table: "schedule",
                column: "doctor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allmeetings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "completedmeetings");

            migrationBuilder.DropTable(
                name: "doctorsperdep");

            migrationBuilder.DropTable(
                name: "familydoctors");

            migrationBuilder.DropTable(
                name: "freeappointmentsweek");

            migrationBuilder.DropTable(
                name: "headdepartment");

            migrationBuilder.DropTable(
                name: "historydocument");

            migrationBuilder.DropTable(
                name: "historymedication");

            migrationBuilder.DropTable(
                name: "historyprocedure");

            migrationBuilder.DropTable(
                name: "manager");

            migrationBuilder.DropTable(
                name: "patientinfo");

            migrationBuilder.DropTable(
                name: "weekschedule");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "medication");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "procedure");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "referral");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "declaration");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "medcard");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
