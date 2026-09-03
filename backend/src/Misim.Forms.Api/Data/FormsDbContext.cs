using Microsoft.EntityFrameworkCore;
using Misim.Forms.Api.Domain;

namespace Misim.Forms.Api.Data;

public class FormsDbContext(DbContextOptions<FormsDbContext> options) : DbContext(options)
{
    public DbSet<FormDefinition> Forms => Set<FormDefinition>();
    public DbSet<FormField> Fields => Set<FormField>();
    public DbSet<FormSubmission> Submissions => Set<FormSubmission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormDefinition>(entity =>
        {
            entity.ToTable("forms");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).IsRequired().HasMaxLength(200);
            entity.Property(x => x.Description).HasMaxLength(2000);
            entity.HasMany(x => x.Fields)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(x => x.Submissions)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FormField>(entity =>
        {
            entity.ToTable("form_fields");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Key).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Label).IsRequired().HasMaxLength(200);
            entity.Property(x => x.Placeholder).HasMaxLength(200);
            entity.Property(x => x.HelpText).HasMaxLength(500);
            entity.Property(x => x.OptionsJson).HasMaxLength(4000);
            entity.Property(x => x.Pattern).HasMaxLength(200);
            entity.HasIndex(x => new { x.FormId, x.Key }).IsUnique();
        });

        modelBuilder.Entity<FormSubmission>(entity =>
        {
            entity.ToTable("form_submissions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.SubmitterName).HasMaxLength(200);
            entity.Property(x => x.ValuesJson).IsRequired();
        });
    }
}
