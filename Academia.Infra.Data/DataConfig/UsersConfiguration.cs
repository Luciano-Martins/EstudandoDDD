using Academia.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Infra.Data.DataConfig
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName)//aqui estamos alterando os valores  do tipos dos campos
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.UserName)
                .HasColumnType("varchar(50)")
                .IsRequired();
           
        }
    }
}
