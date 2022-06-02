using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using testing.Data;

#nullable disable

namespace testing.Models
{
    public partial class MedicalContext : ApplicationDbContext
    {

        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Completedmeeting> Completedmeetings { get; set; }
        public virtual DbSet<Allmeeting> Allmeetings { get; set; }
        public virtual DbSet<Activereferral> Activereferrals { get; set; }
        public virtual DbSet<Declaration> Declarations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Doctorsperdep> Doctorsperdeps { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Familydoctor> Familydoctors { get; set; }
        public virtual DbSet<Freeappointmentsweek> Freeappointmentsweeks { get; set; }
        public virtual DbSet<Headdepartment> Headdepartments { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Historydocument> Historydocuments { get; set; }
        public virtual DbSet<Historymedication> Historymedications { get; set; }
        public virtual DbSet<Historyprocedure> Historyprocedures { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Medcard> Medcards { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Patientinfo> Patientinfos { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Weekschedule> Weekschedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;database=popmedical_test;username=postgres;password=postgres");
            }
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>("gender");
            NpgsqlConnection.GlobalTypeMapper.MapEnum<BloodType>("public.bloodtype");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "bloodtype", new[] { "ZERO_plus", "ZERO_minus", "A_plus", "A_minus", "B_plus", "B_minus", "AB_plus", "AB_minus" })
                .HasPostgresEnum(null, "gender", new[] { "male", "female" })
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.HasIndex(e => e.MedcardId, "IX_appoitment_medcard_id");

                entity.HasIndex(e => e.ReferralId, "IX_appoitment_referral_id");

                entity.HasIndex(e => e.ScheduleId, "IX_appoitment_schedule_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('appoitment_id_seq'::regclass)");

                entity.Property(e => e.Info)
                    .HasMaxLength(100)
                    .HasColumnName("info");

                entity.Property(e => e.MedcardId)
                    .IsRequired()
                    .HasColumnName("medcard_id");

                entity.Property(e => e.ReferralId).HasColumnName("referral_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.HasOne(d => d.Medcard)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.MedcardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appoitment_medcard_id_fkey");

                entity.HasOne(d => d.Referral)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ReferralId)
                    .HasConstraintName("appoitment_referral_id_fkey");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appoitment_schedule_id_fkey");
            });

            modelBuilder.Entity<Completedmeeting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("completedmeetings");

                entity.Property(e => e.Datec).HasColumnName("datec");

                entity.Property(e => e.Dateo).HasColumnName("dateo");

                entity.Property(e => e.Dateop).HasColumnName("dateop");

                entity.Property(e => e.Diag)
                    .HasMaxLength(100)
                    .HasColumnName("diag");

                entity.Property(e => e.Doc)
                    .HasMaxLength(50)
                    .HasColumnName("doc");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("lname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .HasColumnName("pname");
            });

            modelBuilder.Entity<Declaration>(entity =>
            {
                entity.HasKey(e => e.MedcardId)
                    .HasName("declaration_pkey");

                entity.ToTable("declaration");

                entity.HasIndex(e => e.DoctorId, "IX_declaration_doctor_id");

                entity.Property(e => e.MedcardId).HasColumnName("medcard_id");

                entity.Property(e => e.DoctorId)
                    .IsRequired()
                    .HasColumnName("doctor_id");

                entity.Property(e => e.SignDate)
                    .HasColumnType("date")
                    .HasColumnName("sign_date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Declarations)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("declaration_doctor_id_fkey");

                entity.HasOne(d => d.Medcard)
                    .WithOne(p => p.Declaration)
                    .HasForeignKey<Declaration>(d => d.MedcardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("declaration_medcard_id_fkey");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"Department_id_seq\"'::regclass)");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("doctor_pkey");

                entity.ToTable("doctor");

                entity.HasIndex(e => e.DepartmentId, "IX_doctor_department_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.About)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("about");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Cabinet).HasColumnName("cabinet");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("date")
                    .HasColumnName("employment_date");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doctor_department_id_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doctor_Role_RoleId1");
            });

            modelBuilder.Entity<Doctorsperdep>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("doctorsperdep");

                entity.Property(e => e.DoctorsInDepartment).HasColumnName("doctors in department");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Familydoctor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("familydoctors");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.PatientFname)
                    .HasMaxLength(50)
                    .HasColumnName("patient fname");

                entity.Property(e => e.PatientLname)
                    .HasMaxLength(50)
                    .HasColumnName("patient lname");

                entity.Property(e => e.PatientPatro)
                    .HasMaxLength(50)
                    .HasColumnName("patient patro");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.SignDate)
                    .HasColumnType("date")
                    .HasColumnName("sign_date");

                entity.Property(e => e.TotalPatients).HasColumnName("total patients");
            });
            modelBuilder.Entity<Activereferral>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("activereferrals");

                entity.Property(e => e.DeclarationId).HasColumnName("declaration_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.IssuedDate).HasColumnName("issued_date");

            });


            modelBuilder.Entity<Freeappointmentsweek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("freeappointmentsweek");

                entity.Property(e => e.Cabinet).HasColumnName("cabinet");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.DateTime).HasColumnName("date_time");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Headdepartment>(entity =>
            {
                entity.ToTable("headdepartment");

                entity.HasIndex(e => e.DoctorId, "IX_headdepartment_doctor_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId)
                    .IsRequired()
                    .HasColumnName("doctor_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Headdepartments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("headdepartment_doctor_id_fkey");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("History_pkey");

                entity.ToTable("history");

                entity.Property(e => e.AppointmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("appointment_id");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("diagnosis");

                entity.HasOne(d => d.Appointment)
                    .WithOne(p => p.History)
                    .HasForeignKey<History>(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("history_appointment_id_fkey");
            });

            modelBuilder.Entity<Historydocument>(entity =>
            {
                entity.HasKey(e => new { e.HistoryId, e.DocumentId })
                    .HasName("historydocument_pkey");

                entity.ToTable("historydocument");

                entity.HasIndex(e => e.DocumentId, "IX_historydocument_document_id");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Historydocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historydocument_document_id_fkey");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Historydocuments)
                    .HasForeignKey(d => d.HistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historydocument_history_id_fkey");
            });

            modelBuilder.Entity<Historymedication>(entity =>
            {
                entity.HasKey(e => new { e.HistoryId, e.MedicationId })
                    .HasName("historymedication_pkey");

                entity.ToTable("historymedication");

                entity.HasIndex(e => e.MedicationId, "IX_historymedication_medication_id");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

                entity.Property(e => e.MedicationId).HasColumnName("medication_id");

                entity.Property(e => e.Dose)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dose");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Historymedications)
                    .HasForeignKey(d => d.HistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historymedication_history_id_fkey");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.Historymedications)
                    .HasForeignKey(d => d.MedicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historymedication_medication_id_fkey");
            });

            modelBuilder.Entity<Historyprocedure>(entity =>
            {
                entity.HasKey(e => new { e.HistoryId, e.ProcedureId })
                    .HasName("historyprocedure_pkey");

                entity.ToTable("historyprocedure");

                entity.HasIndex(e => e.ProcedureId, "IX_historyprocedure_procedure_id");

                entity.Property(e => e.HistoryId).HasColumnName("history_id");

                entity.Property(e => e.ProcedureId).HasColumnName("procedure_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnName("result");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Historyprocedures)
                    .HasForeignKey(d => d.HistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historyprocedure_history_id_fkey");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.Historyprocedures)
                    .HasForeignKey(d => d.ProcedureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("historyprocedure_procedure_id_fkey");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("manager_pkey");

                entity.ToTable("manager");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.EmploymentDate).HasColumnName("employment_date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");
            });

            modelBuilder.Entity<Medcard>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("medcard_pkey");

                entity.ToTable("medcard");

                entity.HasIndex(e => e.ManagerId, "IX_medcard_manager_id");

                entity.HasIndex(e => e.PatientId, "medcard_patient_id_patient_id1_key")
                    .IsUnique();

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.ExpiredDate).HasColumnName("expired_date");

                entity.Property(e => e.IssuedDate).HasColumnName("issued_date");

                entity.Property(e => e.ManagerId)
                    .IsRequired()
                    .HasColumnName("manager_id");

                entity.HasOne(d => d.Patient)
                    .WithOne(p => p.Medcard)
                    .HasForeignKey<Medcard>(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medcard_patient_id_fkey");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("medication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });


            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("patient_pkey");

                entity.ToTable("patient");

                entity.HasIndex(e => e.UserId, "IX_Patients_UserId");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");
                entity.Property(e => e.BloodType).HasColumnName("blood_type");
                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.SignDate).HasColumnName("sign_date");
            });

            modelBuilder.Entity<Patientinfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("patientinfo");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FamilyDoctorFname)
                    .HasMaxLength(50)
                    .HasColumnName("family doctor fname");

                entity.Property(e => e.FamilyDoctorLname)
                    .HasMaxLength(50)
                    .HasColumnName("family doctor lname");

                entity.Property(e => e.FamilyDoctorPatro)
                    .HasMaxLength(50)
                    .HasColumnName("family doctor patro");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.SignDate)
                    .HasColumnType("date")
                    .HasColumnName("sign_date");
            });

            modelBuilder.Entity<Procedure>(entity =>
            {
                entity.ToTable("procedure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Referral>(entity =>
            {
                entity.ToTable("referral");

                entity.HasIndex(e => e.DepartmentId, "IX_referral_department_id");

                entity.HasIndex(e => e.DeclarationId, "IX_referral_medcard_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeclarationId)
                    .IsRequired()
                    .HasColumnName("declaration_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("date")
                    .HasColumnName("issued_date")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Declaration)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.DeclarationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("referral_declaration_id_fkey");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("referral_department_id_fkey");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.HasIndex(e => e.DoctorId, "IX_schedule_doctor_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime).HasColumnName("date_time");

                entity.Property(e => e.DoctorId)
                    .IsRequired()
                    .HasColumnName("doctor_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_doctor_id_fkey");
            });

            modelBuilder.Entity<Weekschedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("weekschedule");

                entity.Property(e => e.DateTime).HasColumnName("date_time");

                entity.Property(e => e.DoctorFname)
                    .HasMaxLength(50)
                    .HasColumnName("doctor fname");

                entity.Property(e => e.DoctorLname)
                    .HasMaxLength(50)
                    .HasColumnName("doctor lname");

                entity.Property(e => e.DoctorPatronymic)
                    .HasMaxLength(50)
                    .HasColumnName("doctor patronymic");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Info)
                    .HasMaxLength(100)
                    .HasColumnName("info");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .HasColumnName("patronymic");

                entity.Property(e => e.ReferralId).HasColumnName("referral_id");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
