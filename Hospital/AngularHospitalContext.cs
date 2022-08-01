using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalWebApi.Hospital
{
    public partial class AngularHospitalContext : DbContext
    {
        public AngularHospitalContext()
        {
        }

        public AngularHospitalContext(DbContextOptions<AngularHospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblConsultation> TblConsultations { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TblReport> TblReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLSERVER2019G3;Database=AngularHospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__TblAdmin__719FE4886B947570");

                entity.ToTable("TblAdmin");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblConsultation>(entity =>
            {
                entity.HasKey(e => e.ConsultationId)
                    .HasName("PK__TblConsu__5D014A98529C6633");

                entity.ToTable("TblConsultation");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TestReq).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblConsultations)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblConsul__Patie__3B75D760");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__TblPatie__970EC36620C82138");

                entity.ToTable("TblPatient");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__TblRepor__D5BD4805B23D993E");

                entity.ToTable("TblReport");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LabTest)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReportingTo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Consultation)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.ConsultationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TblReport__Consu__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
