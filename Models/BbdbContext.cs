using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial  class BbdbContext : DbContext
{
    public BbdbContext()
    {
    }
   

    public BbdbContext(DbContextOptions<BbdbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<DonorBloodComp> DonorBloodComp { get; set; }


    public virtual DbSet<BbManager> BbManagers { get; set; }

    public virtual DbSet<BloodDonor> BloodDonors { get; set; }

    public virtual DbSet<BloodGroup> BloodGroups { get; set; }

    public virtual DbSet<BloodSpeciman> BloodSpecimen { get; set; }

    public virtual DbSet<DiseaseFinder> DiseaseFinders { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<MainHospital> MainHospitals { get; set; }

    public virtual DbSet<NeedBlood> NeedBloods { get; set; }

    public virtual DbSet<NurseStaff> NurseStaffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E4ELA37;Initial Catalog=BBKMANAGMENTS;Integrated Security=True ;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DonorBloodComp>()
                .HasOne(donorBloodComp => donorBloodComp.BloodGroup)
                .WithMany(bloodGroup => bloodGroup.DonorBloodComps)
                .HasForeignKey(donorBloodComp => donorBloodComp.BloodId);

        modelBuilder.Entity<BbManager>(entity =>
        {
            entity.HasKey(e => e.MId);

            entity.ToTable("BB_Manager");

            entity.Property(e => e.MId).HasColumnName("M_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("M_UserName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BloodDonor>(entity =>
        {
            entity.HasKey(e => e.BdId);

            entity.ToTable("Blood_Donor");

            entity.HasIndex(e => e.BdGroup, "BloodDonorIndx");

            entity.HasIndex(e => e.BdName, "NameDonorIndx");

            entity.Property(e => e.BdId).HasColumnName("BD_ID");
            entity.Property(e => e.BdAge).HasColumnName("BD_Age");
            entity.Property(e => e.BdGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BD_Group");
            entity.Property(e => e.BdName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BD_Name");
            entity.Property(e => e.BdSex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BD_Sex");
            entity.Property(e => e.BdregDate)
                .HasColumnType("datetime")
                .HasColumnName("BDReg_Date");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("City_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NurseId).HasColumnName("Nurse_ID");

            entity.HasOne(d => d.Nurse).WithMany(p => p.BloodDonors)
                .HasForeignKey(d => d.NurseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blood_Donor_NurseStaff");
        });

        modelBuilder.Entity<BloodGroup>(entity =>
        {
            entity.HasKey(e => e.BloodId);

            entity.ToTable("BloodGroup");

            entity.HasIndex(e => e.BloodGroup1, "GroupBloodIndx");

            entity.Property(e => e.BloodId).HasColumnName("Blood_ID");
            entity.Property(e => e.BloodGroup1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Blood_Group");
        });

        modelBuilder.Entity<BloodSpeciman>(entity =>
        {
            entity.HasKey(e => new { e.SpecimenNumber, e.BGroup });

            entity.ToTable("Blood_specimen");

            entity.Property(e => e.SpecimenNumber)
                .ValueGeneratedOnAdd()
                .HasColumnName("Specimen_number");
            entity.Property(e => e.BGroup).HasColumnName("B_group");
            entity.Property(e => e.DfindId).HasColumnName("Dfind_ID");

            entity.HasOne(d => d.BGroupNavigation).WithMany(p => p.BloodSpecimen)
                .HasForeignKey(d => d.BGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blood_specimen_BloodGroup");

            entity.HasOne(d => d.Dfind).WithMany(p => p.BloodSpecimen)
                .HasForeignKey(d => d.DfindId)
                .HasConstraintName("FK_Blood_specimen_DiseaseFinder");
        });

        modelBuilder.Entity<DiseaseFinder>(entity =>
        {
            entity.HasKey(e => e.DfindId);

            entity.ToTable("DiseaseFinder");

            entity.Property(e => e.DfindId).HasColumnName("Dfind_ID");
            entity.Property(e => e.DfindEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dfind_Email");
            entity.Property(e => e.DfindName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dfind_Name");
            entity.Property(e => e.DfindPhone).HasColumnName("Dfind_phone");
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");

            entity.HasOne(d => d.Hospital).WithMany(p => p.DiseaseFinders)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiseaseFinder_MainHospital");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.HospitalNeededBlood).HasName("PK_Hospitals_1");

            entity.Property(e => e.HospitalNeededBlood)
                .ValueGeneratedNever()
                .HasColumnName("Hospital_Needed_Blood");
            entity.Property(e => e.HospNeededQnty).HasColumnName("Hosp_Needed_qnty");
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.HospitalName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Hospital_Name");

            entity.HasOne(d => d.HospitalNavigation).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hospitals_MainHospital");
        });

        modelBuilder.Entity<MainHospital>(entity =>
        {
            entity.HasKey(e => e.HospId);

            entity.ToTable("MainHospital");

            entity.Property(e => e.HospId).HasColumnName("Hosp_ID");
            entity.Property(e => e.BloodGroupId).HasColumnName("Blood_Group_ID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("City_Name");
            entity.Property(e => e.HospName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Hosp_Name");
            entity.Property(e => e.MId).HasColumnName("M_ID");

            entity.HasOne(d => d.BloodGroup).WithMany(p => p.MainHospitals)
                .HasForeignKey(d => d.BloodGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MainHospital_BloodGroup");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.MainHospitals)
                .HasForeignKey(d => d.MId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MainHospital_BB_Manager");
        });

        modelBuilder.Entity<NeedBlood>(entity =>
        {
            entity.HasKey(e => e.NbId);

            entity.ToTable("Need_Blood");

            entity.Property(e => e.NbId).HasColumnName("NB_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.NbAge).HasColumnName("NB_Age");
            entity.Property(e => e.NbEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NB_Email");
            entity.Property(e => e.NbName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NB_Name");
            entity.Property(e => e.ReasonForNb)
                .IsUnicode(false)
                .HasColumnName("ReasonForNB");

            entity.HasOne(d => d.Hospital).WithMany(p => p.NeedBloods)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_Need_Blood_Hospitals");
        });

        modelBuilder.Entity<NurseStaff>(entity =>
        {
            entity.HasKey(e => e.NurseId);

            entity.ToTable("NurseStaff");

            entity.Property(e => e.NurseId).HasColumnName("Nurse_ID");
            entity.Property(e => e.HospitalId).HasColumnName("Hospital_ID");
            entity.Property(e => e.NurseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nurse_Name");
            entity.Property(e => e.NursePhNo).HasColumnName("Nurse_phNo");

            entity.HasOne(d => d.Hospital).WithMany(p => p.NurseStaffs)
                .HasForeignKey(d => d.HospitalId)
                .HasConstraintName("FK_NurseStaff_MainHospital");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
