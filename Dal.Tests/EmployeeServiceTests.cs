using System.Data.Entity.Infrastructure;
using System.Linq;
using Dal.DataModel;
using Dal.DataServices.Implmentation;
using Xunit;

namespace Dal.Tests
{
    [Collection("UseDb")]
    public class EmployeeServiceTests : IClassFixture<EmployeeServiceTestsFixture>
    {
        private readonly EmployeeServiceTestsFixture _fixture;

        private readonly DatabaseContext _dbContext;

        public EmployeeServiceTests(EmployeeServiceTestsFixture fixture)
        {
            _fixture = fixture;
            _dbContext = _fixture.DbContext;
        }

        [Fact]
        public void AddEmployee_NewEmployee_AddedSuccessfully()
        {
            var employeesService = new EmployeesService();
            var employee = new Employee {IdCardNumber = "Test123"};
            Assert.Equal(0, employee.Id);

            employeesService.Add(employee);
            Assert.NotEqual(0, employee.Id );

            //Clear test data
            var createdEmp = _dbContext.Employees.First(x => x.Id == employee.Id);
            _dbContext.Employees.Remove(createdEmp);
        }

        [Fact]
        public void GetEmployee_EmployeeWithBusinessTrips_EmployeeLoadedWithTrips()
        {
            var employeesService = new EmployeesService();
            var employee = employeesService.GetEmployee(_fixture.TestIdCardNumber);

            Assert.NotNull(employee);
            Assert.Equal(2, employee.BusinessTrips.Count);
        }

        [Fact]
        public void AddEmployee_EmployeeWithTheSameIdCardIsInDb_ThrowException()
        {
            var employeesService = new EmployeesService();
            Assert.Throws<DbUpdateException>(() => employeesService.Add(new Employee { IdCardNumber = _fixture.TestIdCardNumber}));
        }
    }
}
