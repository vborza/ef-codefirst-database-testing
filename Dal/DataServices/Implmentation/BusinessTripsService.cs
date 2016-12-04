using System;
using System.Collections.Generic;
using System.Linq;
using Dal.DataModel;

namespace Dal.DataServices.Implmentation
{
    public class BusinessTripsService : IBusinessTripsService
    {
        public void AddBusinessTrip(BusinessTrip trip, IEnumerable<int> participants)
        {
            using (var context = new DatabaseContext())
            {
                trip.Employees = new List<Employee>();

                foreach (var emp in participants.Select(employeeId => new Employee { Id = employeeId }))
                {
                    context.Employees.Attach(emp);
                    trip.Employees.Add(emp);
                }

                context.BusinessTrips.Add(trip);
                context.SaveChanges();
            }
        }
    }
}
