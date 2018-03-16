
using BloodForLifeEntity;
using BloodForLifeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeReposiory
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Admin AdminLoginValidation(Admin entity);
        bool adminDelete(int id);
        bool userDelete(int id);

    }
}
