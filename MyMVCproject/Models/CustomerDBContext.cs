using System.Data.Entity;

namespace MyMVCproject.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext() : base("DBConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}