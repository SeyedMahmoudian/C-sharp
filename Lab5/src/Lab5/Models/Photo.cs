using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId
        {
            get;
            set;
        }
        [Required]
        public string FileName
        {
            get;
            set;
        }
        [Required]
        public string Url
        {
            get;
            set;
        }
    }
}
