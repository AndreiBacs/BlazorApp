namespace BlazorApp.Data
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task GetEmployees();
        void AddOrUpdateEmployee(Employee employee);
        void ArchiveEmployee(Employee employee);
    }
}
