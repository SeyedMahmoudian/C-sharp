using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Controllers
{
    public class Home : Controller
    {
        private Assignment1DataContext _context;

        public Home(Assignment1DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.BlogPosts.ToList());
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser(User _user, Role _role)
        {
            var user = (from u in _context.Users where u.EmailAddress == _user.EmailAddress select u.UserId).FirstOrDefault();
            var role = (from r in _context.Users where r.EmailAddress == _user.EmailAddress select r.RoleId).FirstOrDefault();
            var email = (from e in _context.Users where e.EmailAddress == _user.EmailAddress select e.EmailAddress).FirstOrDefault();
            var password = (from p in _context.Users where p.EmailAddress == _user.EmailAddress select p.Password).FirstOrDefault();
            var firstName = (from f in _context.Users where f.EmailAddress == _user.EmailAddress select f.FirstName).FirstOrDefault();
            var lastName = (from l in _context.Users where l.EmailAddress == _user.EmailAddress select l.LastName).FirstOrDefault();
            if (user == 0)
            {
                return RedirectToAction("Register");
            }

            if (_user.EmailAddress == null)
            {
                return RedirectToAction("Login");
            }
            if (_user.Password == null)
            {
                return RedirectToAction("Login");
            }
            if (_user.EmailAddress != email)
            {
                return RedirectToAction("Login");
            }
            if (_user.Password != password)
            {
                return RedirectToAction("Login");
            }

            int id = Convert.ToInt32(user);
            int id2 = Convert.ToInt32(role);

            HttpContext.Session.SetInt32("UserId", id);
            HttpContext.Session.SetInt32("RoleId", id2);
            HttpContext.Session.SetString("EmailAddress", email);
            HttpContext.Session.SetString("FirstName", firstName);
            HttpContext.Session.SetString("FirstName", lastName);
            HttpContext.Session.SetString("Password", password);

            return RedirectToAction("Index");
        }

        public IActionResult AddBlogPost()
        {
            return View();
        }

        public IActionResult CreateBlog(BlogPost post)
        {

            BlogPost blogAdd = new Assignment1.Models.BlogPost();
            DateTime current = DateTime.Now;
            blogAdd.UserId = (int)HttpContext.Session.GetInt32("UserId");
            blogAdd.Title = post.Title;
            blogAdd.Content = post.Content;
            blogAdd.Posted = current;

            _context.BlogPosts.Add(blogAdd);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

      
        public IActionResult DisplayFullBlogPost(int id)
        {
          
          
            var comments = (from c in _context.Comments where c.BlogPostId == id select c).ToList();

            HttpContext.Session.SetString("Title", (from b in _context.BlogPosts where b.BlogPostId == id select b.Title).FirstOrDefault());
            HttpContext.Session.SetString("Content", (from b in _context.BlogPosts where b.BlogPostId == id select b.Content).FirstOrDefault());
            HttpContext.Session.SetString("Posted", (from b in _context.BlogPosts where b.BlogPostId == id select b.Posted).FirstOrDefault().ToString());
            HttpContext.Session.SetInt32("BlogPostId", id);
   
            return View(comments);

        }
        public IActionResult AddComment(Comment comment)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            Comment comm = new Comment();
            comm.UserId = (int)HttpContext.Session.GetInt32("UserId");
            comm.BlogPostId = (int)HttpContext.Session.GetInt32("BlogPostId");
            comm.Content = comment.Content;

            _context.Comments.Add(comm);
            _context.SaveChanges();
            String test = comm.BlogPostId.ToString();
            return Redirect("DisplayFullBlogPost/"+test);

        }

        public IActionResult EditBlogPost(int id)
        {
            var blogToUpdate = (from b in _context.BlogPosts where b.BlogPostId == id select b).FirstOrDefault();
            return View(blogToUpdate);
        }

        public IActionResult ModifyBlog(BlogPost post, Comment comment)
        {

           // var id = Convert.ToInt32(Request.Form["BlogPostId"]);

            var blogToUpdate = (from b in _context.BlogPosts where b.BlogPostId == post.BlogPostId select b).FirstOrDefault();
            DateTime current = DateTime.Now;
            blogToUpdate.Title = post.Title;
            blogToUpdate.Content = post.Content;
            blogToUpdate.Posted = current;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Logout(User user)
        {
            HttpContext.Session.Clear();
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
