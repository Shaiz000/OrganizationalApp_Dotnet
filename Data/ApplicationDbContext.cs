using Microsoft.EntityFrameworkCore;
using OrganizationalApp.Models.Entities;


namespace OrganizationalApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Users> Users { get; set; }
    }
}
