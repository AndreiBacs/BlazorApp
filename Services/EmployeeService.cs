using AutoFixture;
using BlazorApp.Data;

namespace BlazorApp.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly HAMMERContext _context;

        public EmployeeService(HAMMERContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public async Task GetEmployees()
        {
            //var fixture = new Fixture();

            //var employees = fixture.Create<List<Employee>>();

            //return Task.FromResult(employees);

            Employees = await _context.Employee.Where(x => !x.IsArchived).ToListAsync();
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

        public void ArchiveEmployee(Employee employee)
        {
            var model = _context.Employee.Find(employee.Id);
            if (model != null)
            {
                model.IsArchived = true;
            }
            _context.SaveChanges();
        }
    }
}
