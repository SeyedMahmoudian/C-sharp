﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2.Models
{
    public class BadWords
    {
       [Key]
        public int BadWordId
        {
            get;
            set;
        }
        [Required]
        [StringLength(50)]
        public string Word
        {
            get;
            set;
        }
    }
}
