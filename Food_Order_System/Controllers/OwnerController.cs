using Food_Order_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Order_System.Controllers
{
    public class OwnerController : Controller
    {
        ProjectContext _db;
        IWebHostEnvironment _env;

        public OwnerController(ProjectContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
         }
        [HttpPost]
        public async Task<IActionResult> Login(Owner obj)
        {
            var result = await _db.TblOwner.Where(a => a.Email == obj.Email && a.Password == obj.Password).FirstOrDefaultAsync();
            if (result == null)
            {
                ViewBag.Message = "Invalid Email Addess/Password";
                return View();
            }
            else
            {
                //store the email id of user in session variable
                HttpContext.Session.SetString("OwnerEmail", obj.Email);
                return RedirectToAction("Welcome");
            }
        }
        public async Task<IActionResult> Welcome()
        {
            string email = HttpContext.Session.GetString("OwnerEmail");
            if (email == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var row = await _db.TblOwner.Where(a => a.Email == email).FirstOrDefaultAsync();
                return View(row);
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Purchase_History()
        {
            var OrderList = await _db.TblUser.ToListAsync();
            return View(OrderList);
        }
    }
}
