using Auth.DEPI.Final.DAL.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Auth.DEPI.Final.DAL.Entities; 
using System.Linq;

namespace Auth.DEPI.Final.PL.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Injecting the ApplicationDbContext (replace with your actual context)
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

 
        //public IActionResult Profile(string studentId)
        //{
            
        //    var student = _context.Student.FirstOrDefault(s => s.Id == studentId);

        //    if (student == null)
        //    {
        //        return NotFound(); 
        //    }

        
        //    return View(student);
        //}
    }
}
