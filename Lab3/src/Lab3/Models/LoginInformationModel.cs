using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class LoginInformationModel
    {
        [Required]
        [StringLength(255)]
        public string firstName
        {
            get;
            set;
        }
        [Required]
        [StringLength(255)]
        public string lastName
        {
            get;
            set;
        }
        [Required]
        public string age
        {
            get;
            set;
        }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string emailAddress
        {
            get;
            set;
        }
        [Required]
        public string dateOfBirth
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string password
        {
            get;
            set;
        }
        [Required]
        [MaxLength(75)]
        public string desc
        {
            get;
            set;
        }
    }
}
