using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class User 
    {
        [Key]
        [Required]
        public int UserId
        {
            get;set;
        }
        [Required]
        [ForeignKey("RoleId")]
        public int RoleId
        {
            get;set;
        }

        public virtual Role Role { get; set; }
   

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get;set;
        }
        [Required]
        [StringLength(50)]
        public string LastName
        {
            get; set;
        }
        [Required]
        [StringLength(50)]
        public string EmailAddress
        {
            get; set;
        }
        [Required]
        [StringLength(50)]
        public string Password
        {
            get; set;
        }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
