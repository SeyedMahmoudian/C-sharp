using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Photos
    {
        [Key]
        [Required]
        public int PhotoId
        {
            get;set;
        }
        [Required]
        [StringLength(255)]
        public string FileName
        {
            get;set;
        }
        [Required]
        [StringLength(2048)]
        public string Url
        {
            get;set;
        }
        [Required]
        [ForeignKey("BlogPostId")]

        public int BlogPostId
        {
            get;set;
        }
        BlogPosts blogPost = new BlogPosts();
    }
}
