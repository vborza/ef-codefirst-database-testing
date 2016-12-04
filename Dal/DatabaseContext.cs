using System.Data.Entity;
using Dal.DataModel;

namespace Dal
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("EmployeeTrips")
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<BusinessTrip> BusinessTrips { get; set; }
    }
}
