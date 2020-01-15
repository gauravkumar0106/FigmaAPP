using Figma.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Figma.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set;}
    }
}