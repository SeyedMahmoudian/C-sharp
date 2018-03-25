using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab6.Models
{
    /// <summary>
    /// A class that describes a Tweet
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Database id of the tweet
        /// </summary>
        public int TweetId
        {
            get;
            set;
        }

        /// <summary>
        /// The person who created the tweet
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// The content of the tweet
        /// </summary>
        public string Content
        {
            get;
            set;
        }
    }
}
