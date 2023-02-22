using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpWebApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name is Requirde")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Last Name Should be min 5 and max 20 length")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public double Salary { get; set; }
        public int DeptId { get; set; }
        public virtual Department dept { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation designation { get; set; }
        public ICollection<EmployeeSkill> employeeSkills { get; set; }
        
        public List<Skill> skills { get; set; } 

        //[NotMapped]
        //public List<Department> Lstdept { get; set; }
    }
}
