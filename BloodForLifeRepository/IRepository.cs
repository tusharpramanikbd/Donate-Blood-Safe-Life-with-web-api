using BloodForLifeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeRepository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
       
        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);//pore dekha jabay
       // User GetMatchBlood(string bloodgroup);
        User LoginValidation(User entity);

    }
}
