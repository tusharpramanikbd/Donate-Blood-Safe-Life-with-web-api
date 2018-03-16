using BloodForLifeEntity;
using BloodForLifeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeService
{
    public class  UserService :Service<User>,IUserService
    {
        IRepository<User> repo = new UserRepository();
        public User LoginValidation(User entity)
        {
            return repo.LoginValidation(entity);
        }
       /* public User GetMatchBlood(string bloodgroup)
        {
            return repo.GetMatchBlood(bloodgroup);
        }*/
    }
}
