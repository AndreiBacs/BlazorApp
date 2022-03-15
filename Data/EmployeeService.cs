using AutoFixture;

namespace BlazorApp.Data
{
  public class EmployeeService
  {
    public Task<List<Employee>> GetEmployees()
    {
      var fixture = new Fixture();

      var employees = fixture.Create<List<Employee>>();

      return Task.FromResult(employees);
    }
  }
}
