using BloodForLifeEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace BloodForLifeRepository
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        DataContext context = new DataContext();
        

        public List<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public User GetMatchBlood(string bloodgroup)
        {
            return this.context.Users.SingleOrDefault(e => e.bloodGroup == bloodgroup);
        }

       /* public List<TEntity> GetBlood(TEntity entity)
        {
            return this.context.Set<TEntity>.ToList();
        }*/


        public int Insert(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            return this.context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges();

           
        }

        public int Delete(TEntity entity)
        {
            TEntity userToDelete = this.context.Set<TEntity>().SingleOrDefault(e => e.Id == entity.Id);
            this.context.Set<TEntity>().Remove(userToDelete);

            return this.context.SaveChanges();
        }

       
        public User LoginValidation(User user)
        {
            var usr = this.context.Users.Where(u => u.userName == user.userName && u.password == user.password).FirstOrDefault();

            if (usr != null)
            {
                User u = usr;
                return u;
            }
            else
            {
                return null;
            }
        }

    }
}

