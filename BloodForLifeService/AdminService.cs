using BloodForLifeEntity;
using BloodForLifeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeService
{
    public class AdminService : Service<Admin>, IAdminService
    {
        private AdminRepository repo = new AdminRepository();
        private UserRepository repoUser = new UserRepository();

     

        public Admin AdminLoginValidation(Admin admin)
        {

            Admin adm = this.repo.AdminLoginValidation(admin);

            if (adm != null)
            {

                return adm;
            }
            else
                return null;
        }
        public bool adminDelete(int id)
        {

            bool adm = this.repo.adminDelete(id);
            return adm;
        }

        public bool userDelete(int id)
        {

            bool adm = this.repo.userDelete(id);
            return adm;
        }

     
    }
}
