using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            List<Student> students = universityContext.Student.ToList();
            foreach (Student student in students)
            {
                Debug.WriteLine(" Student : {0} {1} {2} {3} {4} {5} {6}", student.id, student.first_name, student.last_name, student.phone_number, student.university, student.course, student.timestamp);
            }
            StudentRepository studentRep = new StudentRepository(universityContext);
            IEnumerable<String> s = studentRep.GetCourses();

            return View(s);

        }

        public IActionResult getcourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRep = new StudentRepository(universityContext);
            IEnumerable<Student> students = (IEnumerable<Student>)studentRep.Find((s) => s.course.ToLower() == id.ToLower()).ToList();

            ViewBag.course = id;
            if (students.Count() == 0) { ViewBag.NotFound = true; }
            return View(students);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}