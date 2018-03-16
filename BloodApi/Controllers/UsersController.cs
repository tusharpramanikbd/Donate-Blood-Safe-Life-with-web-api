using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BloodForLifeRepository;
using BloodForLifeEntity;
using System.Web.Http.Cors;


namespace BloodApi.Controllers
{
    [RoutePrefix("api/Users")]
    //[EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        DataContext context = new DataContext();

        /*
            /Departments
         */
        [Route("")]
        [HttpGet]

        public IHttpActionResult FindAllUsers()
        {
            List<User> dlist = context.Set<User>().ToList();
            List<User> deptlist = new List<User>();
            foreach (User d in dlist)
            {
                /*d.Links = new List<Link>()
                {
                    new Link(){
                        UrlAddress = Url.Link("UserList", new {id=d.Id}),
                        EntityRelation = "Users"
                    }
                };*/
                deptlist.Add(d);
            }
            //return Content(HttpStatusCode.OK, "Welcome");
            return Ok(deptlist);
        }

        //[Route("{id}", Name = "FindUsers")]
        public IHttpActionResult Get([FromUri]int id)
        {
            User dept = context.Set<User>().Find(id);
            if (dept == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(dept);
        }


    }
}
