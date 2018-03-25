using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId
        {
            get; set;
        }
        [Required]
        [ForeignKey("RoleId")]
        public int RoleId
        {
            get; set;
        }

        public virtual Roles Role { get; set; }


        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get; set;
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
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth
        {
            get; set;
        }

        [Required]
        [StringLength(50)]
        public string City
        {
            get;set;
        }

        [Required]
        [StringLength(50)]
        public string Address
        {
            get; set;
        }

        [Required]
        [StringLength(50)]
        public string PostalCode
        {
            get; set;
        }

        [Required]
        [StringLength(50)]
        public string Country
        {
            get; set;
        }


        public virtual ICollection<Comments> Comment { get; set; }
    }
}
