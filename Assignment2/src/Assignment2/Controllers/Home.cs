using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Controllers
{
    public class Home : Controller
    {
        // GET: /<controller>/
        private Assignment2DataContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public Home(Assignment2DataContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            Users user = null;
            var jsonString = HttpContext.Session.GetString("user");
            if (jsonString != null)
            {
                user = JsonConvert.DeserializeObject<Users>(jsonString);
                ViewData["user"] = user;
            }
            else
            {
                ViewData["user"] = null;
            }

            
            return View(_context.BlogPosts.ToList());
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginUser(Users _user, Roles _role)
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


        public IActionResult CreateBlog(BlogPosts post)
        {

            if ((int)HttpContext.Session.GetInt32("RoleId") == 2)
            {
                BlogPosts blogAdd = new Assignment2.Models.BlogPosts();
                DateTime current = DateTime.Now;
                blogAdd.UserId = (int)HttpContext.Session.GetInt32("UserId");
                blogAdd.Title = post.Title;
                blogAdd.Content = post.Content;
                blogAdd.Posted = current;
                blogAdd.IsAvailable = post.IsAvailable;

                blogAdd.ShortDescription = post.ShortDescription;
                _context.BlogPosts.Add(blogAdd);
                _context.SaveChanges();
                return RedirectToAction("DisplayFullBlogPost/" + blogAdd.BlogPostId);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DisplayFullBlogPost(int id)
        {
            Users user = null;                            // shows a blogpost in its full form
            var jsonString = HttpContext.Session.GetString("user");
            if (jsonString != null)
            {
                user = JsonConvert.DeserializeObject<Users>(jsonString);
                ViewData["RoleId"] = user.RoleId;
                ViewData["UserId"] = user.UserId;

            }
            else
            {
                ViewData["RoleId"] = null;
                ViewData["UserId"] = null;
            }



            var blogToDisplay = (from c in _context.BlogPosts where c.BlogPostId == id select c).Include(p=>p.photos).FirstOrDefault();

            var articlePostedBy = (from c in _context.Users where c.UserId == blogToDisplay.UserId select c).FirstOrDefault();
            ViewData["userName"] = articlePostedBy.FirstName + " " + articlePostedBy.LastName;
            ViewData["emailAddress"] = articlePostedBy.EmailAddress;
            ViewData["comments"] = (from c in _context.Comments where c.BlogPostId == id select c);

            IQueryable<Photos> IPhotos = (from c in _context.Photos where c.BlogPostId == id select c);
            Photos[] photos = IPhotos.ToArray<Photos>();

            ViewData["photos"] = photos;

            return View(blogToDisplay);
        }

        public IActionResult AddComment(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            Comments comment = new Comments();
            var cuurentBlog = (from c in _context.BlogPosts where c.BlogPostId == id select c).FirstOrDefault();
            var jsonString = HttpContext.Session.GetString("user");
            string temp = HttpContext.Request.Form["Content"];      
            temp = temp.ToLower();
            var badWords = (from badword in _context.BadWords select badword);
            var replacements = new Dictionary<string, string>();
            foreach (var word in badWords)
            {
                replacements.Add(word.Word, "****");
            }

            foreach (var replacement in replacements.Keys)
            {
                temp = temp.Replace(replacement, replacements[replacement]);
            }
           // var rating = HttpContext.Session.GetInt32("Rating");
            comment.UserId = (int)userId;
            comment.BlogPostId = cuurentBlog.BlogPostId;
            comment.Content = temp;
            //comment.Rating = (int)rating;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            String test = comment.BlogPostId.ToString();
            return RedirectToAction("DisplayFullBlogPost/" + id);
        }


        public IActionResult EditBlogPost(int id)
        {
            HttpContext.Session.SetInt32("editBlogId", id);
            var blogToEdit = (from c in _context.BlogPosts where c.BlogPostId == id select c).FirstOrDefault();
            return View(blogToEdit);
        }

        public IActionResult EditBlog(BlogPosts newPost)
        {
            var id = Convert.ToInt32(Request.Form["BlogPostId"]);

            var oldPost = (from c in _context.BlogPosts where c.BlogPostId == id select c).FirstOrDefault();
            oldPost.Title = newPost.Title;
            oldPost.Content = newPost.Content;
            oldPost.Posted = newPost.Posted;
            oldPost.ShortDescription = newPost.ShortDescription;
            oldPost.IsAvailable = newPost.IsAvailable;
            IQueryable<Photos> IPhotos = (from c in _context.Photos where c.BlogPostId == id select c);
            Photos[] photos = IPhotos.ToArray<Photos>();

            ViewData["photos"] = photos;
            _context.SaveChanges();

            return RedirectToAction("DisplayFullBlogPost/" + id);
        }

        public IActionResult DeleteBadWord(int id)
        {
            var wordToDelete = (from badword in _context.BadWords where badword.BadWordId == id select badword).FirstOrDefault();
            _context.BadWords.Remove(wordToDelete);
            _context.SaveChanges();
            return RedirectToAction("ViewBadWords");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ICollection<IFormFile> files)
        {
            var blogId = HttpContext.Session.GetInt32("editBlogId");
            // get your storage accounts connection string
            var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cst8359;AccountKey=ecMPpNU6vimZKMDTJG4seALrY7Kq7UJYjgl0/yLanXn857C8xtUJ2sF4ciB6wy9gg+e/YeYbRTaly2DVOxWhXQ==");

            // create an instance of the blob client
            var blobClient = storageAccount.CreateCloudBlobClient();

            // create a container to hold your blob (binary large object.. or something like that)
            // naming conventions for the curious https://msdn.microsoft.com/en-us/library/dd135715.aspx
            var container = blobClient.GetContainerReference("justinsphotostorage");
            await container.CreateIfNotExistsAsync();

            // set the permissions of the container to 'blob' to make them public
            var permissions = new BlobContainerPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            await container.SetPermissionsAsync(permissions);

            // for each file that may have been sent to the server from the client
            foreach (var file in files)
            {
                try
                {
                    // create the blob to hold the data
                    var blockBlob = container.GetBlockBlobReference(file.FileName);
                    if (await blockBlob.ExistsAsync())
                        await blockBlob.DeleteAsync();

                    using (var memoryStream = new MemoryStream())
                    {
                        // copy the file data into memory
                        await file.CopyToAsync(memoryStream);

                        // navigate back to the beginning of the memory stream
                        memoryStream.Position = 0;

                        // send the file to the cloud
                        await blockBlob.UploadFromStreamAsync(memoryStream);
                    }

                    // add the photo to the database if it uploaded successfully
                    var photo = new Photos();
                    photo.Url = blockBlob.Uri.AbsoluteUri;
                    photo.FileName = file.FileName;
                    photo.BlogPostId = (int)blogId;

                    System.Diagnostics.Debug.WriteLine("SomeText");
                    System.Diagnostics.Debug.WriteLine(photo.Url);

                    // Console.WriteLine(photo.Url);

                    _context.Photos.Add(photo);
                    _context.SaveChanges();
                }
                catch
                {

                }
            }

            int id = (int)HttpContext.Session.GetInt32("editBlogId");
            return RedirectToAction("EditBlogPost", new { id = id });
        }

        public IActionResult DeletePhoto(int id)
        {

            var deleteId = (from c in _context.Photos where c.PhotoId == id select c).FirstOrDefault();
            _context.Remove(deleteId);
            var blogId = Convert.ToInt32(Request.Form["BlogPostId"]);
            _context.SaveChanges();
            return RedirectToAction("EditBlogPost"+blogId);
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult EditProfile(int id)
        {

            var user = (from u in _context.Users where u.UserId == id select u).FirstOrDefault();

            return View(user);
        }

        public IActionResult UpdateProfile(Users user)
        {

            var id = Convert.ToInt32(Request.Form["UserId"]);

            var userToUpdate = (from u in _context.Users where u.UserId == id select u).FirstOrDefault();

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;
            userToUpdate.Password = user.Password;
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.Address = user.Address;
            userToUpdate.City = user.City;
            userToUpdate.Country = user.Country;
            userToUpdate.PostalCode = user.PostalCode;
            userToUpdate.RoleId = user.RoleId;

            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteBlogPost(int id)
        {

            var blogPostToDelete = (from blogpost in _context.BlogPosts where blogpost.BlogPostId == id select blogpost).FirstOrDefault();

            var commentsAssociated = (from comment in _context.Comments where comment.BlogPostId == id select comment);

            _context.BlogPosts.Remove(blogPostToDelete);

            foreach (var item in commentsAssociated)
            {
                _context.Comments.Remove(item);
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ViewBadWords()
        {
            var badWords = (from badword in _context.BadWords select badword);

            return View(badWords);
        }

        public IActionResult AddBadWordToDatabase()
        {

            BadWords badWordToAdd = new BadWords();

            badWordToAdd.Word = HttpContext.Request.Form["badword"];

            _context.BadWords.Add(badWordToAdd);

            _context.SaveChanges();

            return RedirectToAction("ViewBadWords");
        }

    }
}
