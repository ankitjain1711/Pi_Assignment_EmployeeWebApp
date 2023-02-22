namespace EmpWebApplication.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public String DesgName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
