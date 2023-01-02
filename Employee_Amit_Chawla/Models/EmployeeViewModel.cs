namespace Employee_Amit_Chawla.Models
{
    public class EmployeeViewModel
    {
        public int Emp_Id { get; set; }
        public string? Emp_First_Name { get; set; }
        public string? Emp_Last_Name { get; set; }
        public string? Profile_Picture { get; set; }
        public string Date_Of_Birth { get; set; }
        public decimal Salary { get; set; }
        public int Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public bool Is_Active { get; set; } = true;
        public string Age { get; set; }
        public IFormFile File { get; set; }
    }
}
