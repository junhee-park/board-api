using BoardApi.DataContext;
using BoardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BoardApi.Controllers
{
    public class BoardsController : ApiController
    {
        // GET: api/Boards
        public List<Board> Get()
        {
            List<Board> list = new List<Board>();
            using (var db = new BoardSystemContext())
            {
                try
                {
                    list = getList(0);
                }
                catch
                {
                    
                }

                
            }
            return list;
        }


        // GET: api/Boards/5
        public List<Board> Get(int page)
        {
            List<Board> list = null;
            list = getList(page);
            
            return list;
        }


        private List<Board> getList(int page)
        {
            using (var db = new BoardSystemContext())
            {
                List<Board> list;
                if (page == 0)
                {
                    list = db.Boards.OrderByDescending(s => s.BoardNum).Take(20).ToList();
                }
                else
                {
                    list = db.Boards.OrderByDescending(s => s.BoardNum).Skip(20 + (page - 1) * 10).Take(10).ToList();
                }

                return list;
            }
        }

        
       

        // POST: api/Boards
        public void Post([System.Web.Http.FromBody]Board board)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BoardSystemContext())
                {
                   try
                    {
                        db.Boards.Add(board);

                            if (db.SaveChanges() > 0)
                            {
                              //  return Redirect("Index");
                           }
                        }
                        catch
                        {
                           // return RedirectToAction("Error", "Home");
                        }

                    }
                    ModelState.AddModelError(string.Empty, "投稿できません。");
                }
        }

        // PUT: api/Boards/5
        public void Put(int id, [System.Web.Http.FromBody]string value)
        {
        }

        // DELETE: api/Boards/5
        public void Delete(int boardNum)
        {
            using (var db = new BoardSystemContext())
            {
                Board board;
                try
                {
                    board = db.Boards.Find(boardNum);
                    db.Boards.Remove(board);
                    db.SaveChanges();
                }
                catch
                {
                    
                }

                
            }
        }
    }
}
