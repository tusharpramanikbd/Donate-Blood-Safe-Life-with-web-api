using BloodForLifeEntity;
using BloodForLifeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodForLife.Controllers
{
    public class UserController : Controller
    {
        private IService<User> service = new Service<User>();
        private IService<Request> request = new Service<Request>();
        private IUserService user = new UserService();


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User u)
        {
            if (ModelState.IsValid)
            {
                this.service.Insert(u);
                return RedirectToAction("../User/Login");
            }

            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

            User usr = this.user.LoginValidation(user);

            if (usr != null)
            {
                Session["Id"] = usr.Id.ToString();
                Session["userName"] = usr.userName.ToString();
                Session["mobile"] = usr.mobileNumber.ToString();
                return RedirectToAction("Profile");
            }
            else
            {
                //ModelState.AddModelError("", "Username or password is wrong.");
                return RedirectToAction("../Home/Index");
            }

        }



        List<Request> req_list = new List<Request>();
        List<Request> res_list = new List<Request>();
        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["Id"] != null)
            {
                int Id = Convert.ToInt32(Session["Id"]);

                List<Request> req = this.request.GetAll();

                foreach (Request u in req)
                {

                        if (u.req_from.ToString() == Session["userName"].ToString())
                        {
                            req_list.Add(u);
                        }
                        else
                        {
                            continue;
                           
                        }
                }
                ViewBag.Request = req_list;

                foreach (Request u in req)
                {

                    if (u.req_to.ToString() == Session["userName"].ToString() && u.status.ToString() == "Pending")
                    {
                        res_list.Add(u);
                    }
                    else if(u.req_to.ToString() == Session["userName"].ToString() && u.status.ToString() != "Pending")
                    {
                        continue;

                    }
                }
                ViewBag.Response = res_list;



                return View(this.service.Get(Id));
            }
            else
            {
                return RedirectToAction("Registration");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Id"] != null)
            {

                User user = this.service.Get(id);
          

            return View(user);
            }
            else return RedirectToAction("../User/Login");
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                this.service.Update(user);
                return RedirectToAction("Profile");
            }
            else
            {
                return View(user);
            }

        }


        [HttpGet]
        public ActionResult Search()
        {
            if (Session["Id"] != null)
            {

                return View();
            }
            else return RedirectToAction("../User/Login");
        }


        List<User> bloodList = new List<User>();
        [HttpPost]
        public ActionResult Search(User user)
        {
            List<User> Users = this.service.GetAll();

            foreach (User u in Users)
            {

                if (u.bloodGroup == user.bloodGroup && u.division == user.division)
                {
                    if(u.Id.ToString()== Session["Id"].ToString())
                    {
                        continue;
                    }
                    else
                    {
                        bloodList.Add(u);
                    }
                }
            }

            ViewBag.Users = bloodList;
            return View("BloodDonerList");
        }



        [HttpGet]
        public ActionResult Password()
        {
            if (Session["Id"] != null)
            {
                //String Id = Session["Id"];

                User user = this.service.Get(Convert.ToInt32(Session["Id"]));

            return View();
            }
            else return RedirectToAction("../User/Login");
        }

        [HttpPost]
        public ActionResult Password(User user)
        {

            if (ModelState.IsValid)
            {
                this.service.Update(user);
                return RedirectToAction("Profile");
            }
            else
            {
                return RedirectToAction("Password");
            }
        }


        public ActionResult Logout()
        {


            //return View();
            Session["Id"] = null;
            Session["userName"] = null;
            // return RedirectToAction("Profile");
            return RedirectToAction("../Home/Index");
        }



        public ActionResult Request(string userName)
        {
            Request req = new Request();
            req.req_from = Session["userName"].ToString();
            req.req_to = userName.ToString();
            req.status = "Pending";

            this.request.Insert(req);
            return RedirectToAction("Search");

        }


        List<Request> req_list1 = new List<Request>();
        public ActionResult Accept(string name, int id)
        {
            //return id.ToString();
            Request req = new Request();

            List<Request> reqall = this.request.GetAll();

            foreach (Request u in reqall)
            {

                if (u.req_from.ToString() == Session["userName"].ToString() && u.req_to.ToString() == name.ToString())
                {
                    req_list1.Add(u);
                    
                }
                else
                {
                    continue;

                }
            }
            ViewBag.Request = req_list1;

            req.Id = id;
            req.req_from = name.ToString(); 
            req.req_to = Session["userName"].ToString();
            req.status = Session["mobile"].ToString();


                this.request.Delete(req);
                this.request.Insert(req);

            return RedirectToAction("Profile");
          

        }

        public ActionResult Deny(string name, int id)
        {
            //return id.ToString();
            Request req = new Request();

            List<Request> reqall = this.request.GetAll();

            foreach (Request u in reqall)
            {

                if (u.req_from.ToString() == Session["userName"].ToString() && u.req_to.ToString() == name.ToString())
                {
                    req_list1.Add(u);

                }
                else
                {
                    continue;

                }
            }
            ViewBag.Request = req_list1;

            req.Id = id;
            req.req_from = name.ToString();
            req.req_to = Session["userName"].ToString();
            req.status = Session["mobile"].ToString();


            this.request.Delete(req);
            //this.request.Insert(req);

            return RedirectToAction("Profile");


        }

    }


}
