using System;
using System.Collections.Generic;
using System.Linq;
using Dal.DataModel;
using Dal.DataServices.Implmentation;
using Xunit;

namespace Dal.Tests
{
    [Collection("UseDb")]
    public class BusinessTripsServiceTests : IDisposable
    {
        private readonly DatabaseContext _dbContext;

        public BusinessTripsServiceTests()
        {
            _dbContext = new DatabaseContext();
        }

        [Fact]
        public void AddBusinessTrip_TwoParticipants_AddedSuccessfully()
        {
            //setup
            var emp1 = new Employee { FirstName = "Viktor", IdCardNumber = "Test1"};
            var emp2 = new Employee { FirstName = "Martin", IdCardNumber = "Test2"};
            _dbContext.Employees.Add(emp1);
            _dbContext.Employees.Add(emp2);
            _dbContext.SaveChanges();

            var businessTripsService = new BusinessTripsService();
            var trip = new BusinessTrip { Date = DateTime.Today, Kms = 10 };
            Assert.Equal(0, trip.Id);

            businessTripsService.AddBusinessTrip(trip, new List<int> { emp1.Id, emp2.Id });
            Assert.NotEqual(0, trip.Id);

            var bTrip = _dbContext.BusinessTrips.First(x => x.Id == trip.Id);
            Assert.Equal(2, trip.Employees.Count);

            //clear
            var emps = _dbContext.Employees.Where(x => x.Id == emp1.Id || x.Id == emp2.Id);
            _dbContext.Employees.RemoveRange(emps);
            _dbContext.BusinessTrips.Remove(bTrip);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
