namespace DAL.Models;

public partial class CoHousingContext : DbContext
{
    public CoHousingContext()
    {
    }

    public CoHousingContext(DbContextOptions<CoHousingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<MonthlyExpense> MonthlyExpenses { get; set; }

    public virtual DbSet<OneTimeExpense> OneTimeExpenses { get; set; }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\User\\Desktop\\פרויקט לעבודה יום שני\\CoHousingProject\\Data\\CoHousingData.mdf\";Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingCode).HasName("PK__tmp_ms_x__D4DA032581DBFEDE");

            entity.Property(e => e.BuildingBalance).HasColumnType("money");
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Street)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<MonthlyExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenditureId).HasName("PK__tmp_ms_x__5C07CE9DDA67FFA5");

            entity.Property(e => e.ExpenditureId).HasColumnName("ExpenditureID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.BuildingCodeNavigation).WithMany(p => p.MonthlyExpenses)
                .HasForeignKey(d => d.BuildingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonthlyExpenses_ToTable");
        });

        modelBuilder.Entity<OneTimeExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenditureId).HasName("PK__tmp_ms_x__5C07CE9DA0A58607");

            entity.ToTable("One-timeExpenses");

            entity.Property(e => e.ExpenditureId).HasColumnName("ExpenditureID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.BuildingCodeNavigation).WithMany(p => p.OneTimeExpenses)
                .HasForeignKey(d => d.BuildingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_ToTable");
        });

        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.HasKey(e => e.ProposalId).HasName("PK__tmp_ms_x__6F39E120B7CFA218");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Done)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TenantId)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TenantID");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proposals_ToTable");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__tmp_ms_x__2E9B478135A8BB9B");

            entity.Property(e => e.TenantId)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TenantID");
            entity.Property(e => e.Balance)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.BuildingCodeNavigation).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.BuildingCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tenants_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
