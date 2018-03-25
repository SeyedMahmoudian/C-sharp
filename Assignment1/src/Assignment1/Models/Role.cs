using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class Role
    {
        [Key]
        [Required]
        public int RoleId
        {
            get; set;
        }
        
        [Required]
        [StringLength(50)]
        public string Name
        {
            get; set;
        }
    }
}
