
using Academia.Domain.Entities.Account;
using Academia.Infra.Data.DataConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.Contexto
{
    public class DataContexto : IdentityDbContext<Users>
    {
        public DataContexto(DbContextOptions<DataContexto> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(new UsersConfiguration().Configure);
            base.OnModelCreating(modelBuilder);
        }
     

    }
}
