using System;
using System.Collections.Generic;
using System.Linq;
using Dal.DataModel;

namespace Dal.Tests
{
    public class EmployeeServiceTestsFixture : IDisposable
    {
        public string TestIdCardNumber => "0897531a9";

        public readonly DatabaseContext DbContext;

        public EmployeeServiceTestsFixture()
        {
            DbContext = new DatabaseContext();
            InitializeTestEntries();
        }

        private void InitializeTestEntries()
        {
            var employee = new Employee
            {
                FirstName = "Viktor",
                LastName = "Borza",
                IdCardNumber = TestIdCardNumber,
                BusinessTrips = new List<BusinessTrip>
                    {
                        new BusinessTrip {Date = DateTime.Today, Kms = 43},
                        new BusinessTrip {Date = DateTime.Today.AddDays(-1), Kms = 156}
                    }
            };

            DbContext.Employees.Add(employee);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            RemoveTestEntries();
            DbContext.Dispose();
        }

        private void RemoveTestEntries()
        {
            var employee = DbContext.Employees.Single(x => x.IdCardNumber == TestIdCardNumber);
            var trips = DbContext.BusinessTrips.Where(x => x.Kms == 43 || x.Kms == 156).ToList();
            DbContext.Employees.Remove(employee);
            DbContext.BusinessTrips.RemoveRange(trips);
            DbContext.SaveChanges();
        }
    }
}