using BloodForLifeEntity;
using BloodForLifeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeService
{
   public interface IUserService : IService<User>
    {
        User LoginValidation(User entity);
       // User GetMatchBlood(string bloodgroup);

    }
}
