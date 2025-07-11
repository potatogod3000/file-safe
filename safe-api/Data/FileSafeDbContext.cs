using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using safe_api.Models;

namespace safe_api.Data;

public class FileSafeDbContext: IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<FileModel> Files { get; set; }
    
    public DbSet<FolderModel> Folders { get; set; }
    
    public FileSafeDbContext(DbContextOptions options): base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<FolderModel>()
            .HasMany(folder => folder.Files)
            .WithMany(file => file.Folders);

        builder.Entity<FolderModel>()
            .HasOne(folder => folder.User)
            .WithMany()
            .HasForeignKey(file => file.UserId);
        
        builder.Entity<FileModel>()
            .HasOne(file => file.User)
            .WithMany()
            .HasForeignKey(file => file.UserId);
    }
}