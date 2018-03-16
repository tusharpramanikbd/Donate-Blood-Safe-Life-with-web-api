using BloodForLifeEntity;
using BloodForLifeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodForLife.Controllers
{


    public class HomeController : Controller
    {
        private int Op = 0;
        private int On = 0;
        private int Ap = 0;
        private int An = 0;
        private int Bp = 0;
        private int Bn = 0;
        private int ABp = 0;
        private int ABn = 0;

        private IService<User> usrservice = new Service<User>();
        private IUserService user = new UserService();
        // GET: Home
        public ActionResult Index()
        {
            getAvailableMember();
            ViewBag.Op = Op;
            ViewBag.On = On;
            ViewBag.Ap = Ap;
            ViewBag.An = An;
            ViewBag.Bp = Bp;
            ViewBag.Bn = Bn;
            ViewBag.ABp= ABp;
            ViewBag.ABn = ABn;

            return View();
        }


        private void getAvailableMember()
        {

            List<User> Users = this.usrservice.GetAll();

            foreach (User u in Users)
            {

                if (u.bloodGroup == "O+")
                {
                    Op++;

                }
                else if (u.bloodGroup == "O-")
                {
                    On++;

                }
                else if (u.bloodGroup == "A+")
                {
                    Ap++;

                }
                else if (u.bloodGroup == "A-")
                {
                    An++;

                }
                else if (u.bloodGroup == "B+")
                {
                    Bp++;

                }
                else if (u.bloodGroup == "B-")
                {
                    Bn++;

                }
                else if (u.bloodGroup == "AB+")
                {
                    ABp++;

                }
                else if (u.bloodGroup == "AB-")
                {
                    ABn++;

                }

            }
        }
    }

   
}
