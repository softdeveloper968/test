
using Employee_Amit_Chawla.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objCatlist = _context.Employees;
            return View(objCatlist);
        }
        public List<EmployeeViewModel> LoadData()
        {
            var host = HttpContext.Request.IsHttps ? $"https://{HttpContext.Request.Host}" : $"http:{HttpContext.Request.Host}";
            var result = (from emp in _context.Employees
                          join dep in _context.Departments on emp.Dept_Id equals dep.Dept_Id
                          select new EmployeeViewModel
                          {
                              Emp_Id = emp.Emp_Id,
                              Emp_First_Name = emp.Emp_First_Name,
                              Emp_Last_Name = emp.Emp_Last_Name,   
                              Date_Of_Birth = emp.Date_Of_Birth.ToShortDateString(), 
                              Profile_Picture = host + "/UploadedFiles/" + emp.Profile_Picture,
                              Salary = emp.Salary,
                              Is_Active = emp.Is_Active,
                              Dept_Id = emp.Dept_Id,
                              Dept_Name = dep.Dept_Name,
                              Age = (DateTime.Now.Year - emp.Date_Of_Birth.Year).ToString()
                          }).ToList();
            return result;
        }
        public IActionResult Create()
        {
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel empobj)
        {
            List<Department> departments = _context.Departments.ToList();
            ViewBag.Departments = departments;
            var file = empobj.File;
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot\\UploadedFiles"));
            if (file != null)
            {
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {

                    file.CopyToAsync(fileStream);
                }

            }
            Employee employee = new Employee()
            {
                Emp_Id = empobj.Emp_Id,
                Emp_First_Name = empobj.Emp_First_Name,
                Emp_Last_Name = empobj.Emp_Last_Name,
                Date_Of_Birth = Convert.ToDateTime(empobj.Date_Of_Birth).Date,
                Profile_Picture = file.FileName,
                Salary = empobj.Salary,
                Is_Active = empobj.Is_Active,
                Dept_Id = empobj.Dept_Id,
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return View(empobj);
        }

        public IActionResult Edit(string id)
        {
            if (id == null || id == "0")
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(Convert.ToInt32(id));

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee empobj)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(empobj);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empfromdb = _context.Employees.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpGet]
        public IActionResult DeleteEmp(int id)
        {
            var deleterecord = _context.Employees.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            //Index();
            return Ok();
        }

        [HttpGet]
        public List<EmployeeViewModel> GetEmployeesByFilteredSalary(int fromSalary, int toSalary )
        {
            var host = HttpContext.Request.IsHttps ? $"https://{HttpContext.Request.Host}" : $"http:{HttpContext.Request.Host}";
            var result = (from emp in _context.Employees
                          join dep in _context.Departments on emp.Dept_Id equals dep.Dept_Id
                          where emp.Salary >= fromSalary && emp.Salary <= toSalary
                          select new EmployeeViewModel
                          {
                              Emp_Id = emp.Emp_Id,
                              Emp_First_Name = emp.Emp_First_Name,
                              Emp_Last_Name = emp.Emp_Last_Name,
                              Date_Of_Birth = emp.Date_Of_Birth.ToShortDateString(),
                              Profile_Picture = host + "/UploadedFiles/" + emp.Profile_Picture,
                              Salary = emp.Salary,
                              Is_Active = emp.Is_Active,
                              Dept_Id = emp.Dept_Id,
                              Dept_Name = dep.Dept_Name,
                              Age = (DateTime.Now.Year - emp.Date_Of_Birth.Year).ToString()
                          }).ToList();

            return result;
        }


    }
}