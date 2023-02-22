namespace EmpWebApplication.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<EmployeeSkill> employeeSkills { get; set; }

        public List<Employee> employees { get; set; }
    }
}
