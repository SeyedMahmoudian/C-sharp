using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class Comment 
    {
        [Key]
        public int CommentId
        {
            get;
            set;
        }
        
        [ForeignKey("BlogPost")]
        public int BlogPostId
        {
            get;set;
        }
        
        [ForeignKey("UserId")]
        public int UserId
        {
            get;set;
        }
        
        [Required]
        [StringLength(2048)]
        public string Content
        {
            get;set;
        }

        public virtual User User { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
