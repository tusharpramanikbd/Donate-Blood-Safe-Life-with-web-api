using BloodForLifeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeService
{
    public interface IAdminService : IService<Admin>
    {
        Admin AdminLoginValidation(Admin admin);
        bool adminDelete(int id); 
        bool userDelete(int id); 
    }
}
