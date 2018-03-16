using BloodForLifeEntity;
using BloodForLifeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodForLife.Controllers
{

    public class AdminController : Controller
    {
        private IService<Admin> service = new Service<Admin>();
        private IAdminService admin = new AdminService();

        private IService<User> usrservice = new Service<User>();
        private IUserService user = new UserService();
        // GET: Admin

        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                return View();
            }
            else
            {
                return RedirectToAction("../Admin/Login");
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            Admin adm = this.admin.AdminLoginValidation(admin);

            if (adm != null)
            {
                Session["Id"] = adm.Id.ToString();
                Session["username"] = adm.userName.ToString();
                return RedirectToAction("Profile");
            }
            else
                return RedirectToAction("../Admin/Login");
        }

        [HttpGet]
        public ActionResult ViewAllmember()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                // UserRepository us = new UserRepository();

                List<User> Users = this.usrservice.GetAll();

                return View(Users);
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }

        }
        [HttpGet]
        public ActionResult showAllAdmin()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                // UserRepository us = new UserRepository();

                List<Admin> Admins = this.service.GetAll();

                return View(Admins);
            }
            else
            {
                return RedirectToAction("../Admin/Login");
            }

        }
        List<User> bloodList = new List<User>();
        [HttpGet]
        public ActionResult Active()
        {
            if (Session["Id"] != null)
            {
                List<User> Users = this.usrservice.GetAll();

                foreach (User u in Users)
                {

                    if (u.available == "Yes")
                    {
                        bloodList.Add(u);

                    }

                }

                ViewBag.Users = bloodList;
                return View();
            }
            else return RedirectToAction("../Admin/Login");
         
        }

        [HttpGet]
        public ActionResult Registration()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                return View();
            }
            else
            {
                return RedirectToAction("Profile");
            }

        }

        [HttpPost]
        public ActionResult Registration(Admin admin)
        {
            if (ModelState.IsValid)
            {
                this.service.Insert(admin);
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }

        }



        [HttpGet]
        public ActionResult UserRegistration()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                return View();
            }
            else
            {
                return RedirectToAction("Profile");
            }

        }

        [HttpPost]
        public ActionResult UserRegistration(User usr)
        {
            if (ModelState.IsValid)
            {
                this.usrservice.Insert(usr);
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Search( FormCollection formCollection)
        {

            String user_name = formCollection.Get("user_name");
           // System.Console.WriteLine(user_name);
            if (Session["Id"] != null)
            {
                List<User> Users = this.usrservice.GetAll();

                foreach (User u in Users)
                {

                    if (u.userName == user_name)
                    {
                        bloodList.Add(u);

                    }

                }

                ViewBag.Users = bloodList;
                return View();
            }
            else return RedirectToAction("../Admin/Login");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Id"] != null)

                return View(this.service.Get(id));
            else return RedirectToAction("../Admin/Login");
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteAdmin(int id)
        {  
            this.admin.adminDelete(id);

            return RedirectToAction("showAllAdmin");
        }




        [HttpGet]
        public ActionResult DeleteMember(int id)
        {
            if (Session["Id"] != null)

                return View(this.usrservice.Get(id));
            else return RedirectToAction("../Admin/Login");
        }


        [HttpPost, ActionName("DeleteMember")]
        public ActionResult DeleteMemberbyid(int id)
        {
            this.admin.userDelete(id);

            return RedirectToAction("ViewAllmember");
        }



        public ActionResult Logout()
        {



            Session["Id"] = null;
            Session["userName"] = null;

            return RedirectToAction("../Admin/Login");
        }

    }
}