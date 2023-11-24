using FileUploadingWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FileUploadingWebAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileModel> Files { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>().ToTable("Files");
    }
}
