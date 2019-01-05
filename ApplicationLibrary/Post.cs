using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class Post
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Post(string message, int userId)
        {
            Message = message;
            UserId = userId;
            CreatedDate = DateTime.Now;
        }
    }
}
