using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class Board
    {
        private List<Post> Posts = new List<Post>();

        public Post AddPost(string message, int userId)
        {
            var post = new Post(message, userId);
            this.Posts.Add(post);
            return post;
        }

        public List<Post> GetPosts()
        {
            return Posts.OrderByDescending(post => post.CreatedDate).ToList();
        }
    }
}
