using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaintyTask.Models.DB;

namespace PaintyTask.DbProvider;

public class AppDbContext : IdentityDbContext<DbAppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}