using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Comments
    {
        [Key]
        public int CommentId
        {
            get;
            set;
        }

        [ForeignKey("BlogPostId")]
        public int BlogPostId
        {
            get; set;
        }

        [ForeignKey("UserId")]
        public int UserId
        {
            get; set;
        }

        [Required]
        [StringLength(2048)]
        public string Content
        {
            get; set;
        }
        [Required]
        public int Rating
        {
            get;set;
        }
        public virtual Users User { get; set; }

        public virtual BlogPosts BlogPost { get; set; }
    }
}
