using BoardApi.DataContext;
using BoardApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoardApi.Controllers
{
    public class CommentsController : ApiController
    {
        // GET: api/Comments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comments/5
        public IEnumerable<Comment> Get(int boardNum)
        {
            IEnumerable<Comment> commentList = new List<Comment>();
            using (var db = new BoardSystemContext())
            {
                try
                {
                    commentList = db.Comments.ToList().Where(d => d.BoardNum.Equals(boardNum));
                    
                }
                catch
                {
                    
                }

                
            }
            return commentList;
        }

        // POST: api/Comments
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
        }
    }
}
