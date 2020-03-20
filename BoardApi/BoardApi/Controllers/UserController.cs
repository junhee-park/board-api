using BoardApi.DataContext;
using BoardApi.Models;
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
    public class UserController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            
            return "asdf";
        }

        // POST api/values
        public bool Post([FromBody]User user)
        {
            bool accountProduct = false;
            if (ModelState.IsValid)
            {
                using (var db = new BoardSystemContext())
                {
                    db.Users.Add(user);
                    try
                    {
                        db.SaveChanges();
                        accountProduct = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }
                
            }


            Console.Write(user);
            return accountProduct;
        }

        public bool Post([FromBody]User user, int id)
        {
            User loginUser = null;
            bool login = false;
            using (var db = new BoardSystemContext())
            {
                try
                {
                    loginUser = db.Users.FirstOrDefault(u => u.UserId.Equals(user.UserId) && u.UserPassword.Equals(user.UserPassword));
                    if (loginUser != null)
                    {
                        login = true;
                    }
                    
                }
                catch
                {
                    //return RedirectToAction("Error", "Home");
                }
                
            }
            
            Console.Write(user);
            return login;
        }



        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
