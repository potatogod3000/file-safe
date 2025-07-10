using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace safe_api.Data;

public class FileSafeDbContext: IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public FileSafeDbContext(DbContextOptions options): base(options) {}
}