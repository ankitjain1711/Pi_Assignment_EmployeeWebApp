using Microsoft.AspNetCore.Mvc;
using EmpWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController (EmployeeContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var emp = _context.emps.ToList();
            List<Skill> skills = _context.skill.ToList();
            ViewBag.Skills = skills;
            return View(emp);

        }

        public IActionResult Create()
        {
            List <Skill> skills = _context.skill.ToList();
            ViewBag.Skills = skills;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee empForm)

        {
            _context.emps.Add(empForm);
            _context.SaveChanges();

            string sk = Request.Form["SkillName"];
            
            List<int> list = sk.Split(',').Select(int.Parse).ToList();
            List<Skill> skills = new List<Skill>();
           
            foreach (int i in list)
            {
                Skill skr = _context.skill.Find(i);
                skills.Add(skr);
            }

            empForm.skills = skills;
            _context.Update(empForm);

            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: EmpForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmploye(Employee p_employee)
        {
            
            Employee empForm = p_employee;
            _context.emps.Add(empForm);
            _context.SaveChanges();

            string sk = Request.Form["skills"];
            List<int> list = sk.Split(',').Select(int.Parse).ToList();
            List<Skill> skills = new List<Skill>();

            foreach (int i in list)
            {
                Skill skr = _context.skill.Find( i );
                skills.Add(skr);
            }

            empForm.skills=skills;
            _context.Update(empForm);

            _context.SaveChanges();
            // return Ok();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index");
        }

        //Get Edit Form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.emps == null)
            {
                return NotFound();
            }

            var employee = _context.emps.Include(c=> c.skills).FirstOrDefault(x=>x.Id == id);

            //var employee = _context.emps.Include(c => c.skills.Select(s => s.ThirdTable)).FirstOrDefault(x => x.Id == id);
            //the Include method is called on the skills property, and 
            //the Select method is used to select the related data from the ThirdTable.
            //The employee object will now contain not only the data for the requested employee, 
            //but also the data from the related skills and ThirdTable records.

            if (employee == null)
            {
                return NotFound();
            }

            List<Skill> skill_emp = employee.skills;
            ViewBag.Skills1 = skill_emp;
            List<Skill> skills = _context.skill.ToList();
            skills = skills.Except(skill_emp).ToList();
            ViewBag.Skills = skills;

            return View(employee);
        }

        // Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DOB,Salary,Gender,DesignationId,DeptId,skills")] Employee empForm)
        public async Task<IActionResult> Edit(int id, Employee empForm)
        {
            if (id != empForm.Id)
            {
                return NotFound();
            }

            _context.Update(empForm);
            _context.SaveChanges();
            empForm = _context.emps.Include(c => c.skills).FirstOrDefault(x => x.Id == id);
            empForm.skills.RemoveAll(x=>true);
            _context.SaveChanges();

            string sk = Request.Form["SkillName"];
            List<int> list = sk.Split(',').Select(int.Parse).ToList();
            List<Skill> skills = new List<Skill>();
            
            foreach (int i in list)
            {
                Skill skr = _context.skill.Find(i);
                skills.Add(skr);
            }

            empForm.skills = skills;
            _context.Update(empForm);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }        
        
        // GET: EmpForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.emps == null)
            {
                return NotFound();
            }

            var empForm = await _context.emps.FirstOrDefaultAsync(m => m.Id == id);

            if (empForm == null)
            {
                return NotFound();
            }

            return View(empForm);
        }

        // POST: EmpForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.emps == null)
            {
                return Problem("Entity set 'webapp.Employee'  is null.");
            }
            var empForm = await _context.emps.FindAsync(id);
            if (empForm != null)
            {
                _context.emps.Remove(empForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.emps == null)
            {
                return NotFound();
            }

            var empForm = await _context.emps.FirstOrDefaultAsync(m => m.Id == id);
            if (empForm == null)
            {
                return NotFound();
            }

            return View(empForm);
        }

        //public ActionResult find(String search)
        //{
        //    var employee = _context.emps.Where(m => m.FirstName == search).ToList();
        //    return View(employee);
        //}

        public IActionResult find (String search)
        {
            var empForm = _context.emps.FromSqlRaw($"FindEmployeeByNameLike {search}").ToList();
            return View(empForm);
        }

    }
}
