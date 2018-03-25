using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class BlogPosts
    {
        [Key]
        public int BlogPostId
        {
            get;
            set;
        }

        [ForeignKey("UserId")]
        public int UserId
        {
            get;
            set;
        }
        Users user = new Users();
        [Required]
        [StringLength(200)]
        public string Title
        {
            get;
            set;
        }

        [Required]
        [StringLength(4000)]
        public string Content
        {
            get;
            set;
        }
        [Required]
        [StringLength(400)]
        public string ShortDescription
        {
            get;set;
        }



        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Posted
        {
            get;
            set;
        }

        [Required]
        public Boolean IsAvailable
        {
            get;set;
        }

        public virtual ICollection<Photos> photos
        {
            get;
            set;
        }
    }
}
