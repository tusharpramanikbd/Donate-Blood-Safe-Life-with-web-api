using BloodForLifeEntity;
using BloodForLifeReposiory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BloodForLifeRepository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private DataContext context = new DataContext();

        

        public Admin AdminLoginValidation(Admin ad)
        {
            var adm = this.context.Admins.Where(u => u.userName == ad.userName && u.password == ad.password).FirstOrDefault();

            if (adm != null)
            {
                Admin u = adm;
                return u;
            }
            else
            {
                return null;
            }
        }

        public bool adminDelete(int id)
        {

            Admin adminToDelete = this.context.Admins.SingleOrDefault(e => e.Id == id);
            this.context.Admins.Remove(adminToDelete);

             this.context.SaveChanges();
            return true;
        }
        public bool userDelete(int id)
        {
            User userToDelete = this.context.Users.SingleOrDefault(e => e.Id == id);
            this.context.Users.Remove(userToDelete);

         this.context.SaveChanges();
            return true;
        }

    }


}
