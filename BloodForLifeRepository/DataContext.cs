using BloodForLifeEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeRepository
{

    public class DataContext : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Request> Requests { get; set; }

    }

}
