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
    public class BoardContentsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Board Get(int boardNum)
        {
            Board board;
            using (var db = new BoardSystemContext())
            {
                board = db.Boards.FirstOrDefault(u => u.BoardNum.Equals(boardNum));
                db.Entry(board).Entity.BoardViews = board.BoardViews + 1;
                db.SaveChanges();

            }
            return board;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}