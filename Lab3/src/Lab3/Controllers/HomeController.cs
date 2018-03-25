using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab3.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Razor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DisplayPerson()
        {
            HttpContext.Session.SetString("emailAddress", Request.Form["emailAddress"]);
            HttpContext.Session.SetString("password", Request.Form["password"]);

            return View();
        }
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DisplayForm(LoginInformationModel model)
        {
            return View(model);
        }
    }
}
