using System.ComponentModel.DataAnnotations;

namespace Employee_Amit_Chawla.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }
        public string? Emp_First_Name { get; set; }
        public string? Emp_Last_Name { get; set; }
        public string? Profile_Picture { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public decimal Salary { get; set; }
        public int Dept_Id { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}
