using System.Data.Entity;
using System.Linq;
using Dal.DataModel;

namespace Dal.DataServices.Implmentation
{
    public class EmployeesService : IEmployeesService
    {
        public void Add(Employee employee)
        {
            using (var context = new DatabaseContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public Employee GetEmployee(string idCardNumber)
        {
            using (var context = new DatabaseContext())
            {
                var emps = context.Employees.Where(x => x.IdCardNumber == idCardNumber).Include(e => e.BusinessTrips);
                return emps.FirstOrDefault();
            }
        }
    }
}