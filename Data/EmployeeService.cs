using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
  public class EmployeeService
  {
    private readonly HAMMERContext _context;

    public EmployeeService(HAMMERContext context)
    {
      _context = context;
    }

    public async Task<List<Employee>> GetEmployees()
    {
      //var fixture = new Fixture();

      //var employees = fixture.Create<List<Employee>>();

      //return Task.FromResult(employees);

      return await _context.Employee.ToListAsync();
    }

    public void AddOrUpdateEmployee(Employee employee)
    {
      var model = employee.Id > 0 ? _context.Employee.Where(x => x.Id == employee.Id).FirstOrDefault() : employee;
      if (model?.Id > 0)
      {
        model.FirstName = employee.FirstName;
        model.LastName = employee.LastName;
        model.Department = employee.Department;
        model.EntryDate = employee.EntryDate;
        model.Tasks = employee.Tasks;
      }
      else
      {
        _context.Employee.Add(model);
      }

      _context.SaveChanges();
    }
  }
}
