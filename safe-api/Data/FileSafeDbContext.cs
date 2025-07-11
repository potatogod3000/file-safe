using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using safe_api.Models;

namespace safe_api.Data;

public class FileSafeDbContext: IdentityDbContext<IdentityUser, IdentityRole, string>
{
    DbSet<FileModel> Files { get; set; }
    DbSet<FolderModel> Folders { get; set; }
    
    public FileSafeDbContext(DbContextOptions options): base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<FolderModel>()
            .HasMany(folder => folder.Files)
            .WithMany(file => file.Folders);
        
        base.OnModelCreating(builder);
    }
}