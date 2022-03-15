using System.ComponentModel.DataAnnotations;


namespace BlazorApp.Data
{
  public class Employee
  {
    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string Department { get; set; }

    [Required]
    public DateTime EntryDate { get; set; }

    [Required]
    public List<string> Tasks { get; set; }
  }
}
