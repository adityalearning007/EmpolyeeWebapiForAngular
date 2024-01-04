using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Int64  Contact { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }
        public DateTime? DOJ { get; set; }
    }
    public class EmployeeData
    { 
        public string? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string? doj { get; set; }

    }
}
