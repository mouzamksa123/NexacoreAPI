using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
      

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(c => c.FullName).IsRequired();
            builder.Property(c => c.FullName).HasMaxLength(250);
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50);
        }
    }
}
