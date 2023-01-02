using System.ComponentModel.DataAnnotations;

namespace Employee_Amit_Chawla.Models
{
    public class Department
    {
        [Key]
        public int Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public bool Is_Active { get; set; }
    }
}
