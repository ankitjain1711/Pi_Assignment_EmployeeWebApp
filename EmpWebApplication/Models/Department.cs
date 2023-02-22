using System.ComponentModel.DataAnnotations;

namespace EmpWebApplication.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public String? DeptName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
