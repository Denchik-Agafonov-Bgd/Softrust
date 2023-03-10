using SofTrust.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace SofTrust.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Subject> Subject => Set<Subject>();

        public DbSet<Person> Person => Set<Person>();

        public DbSet<Message> Message => Set<Message>();
       
    }
}
