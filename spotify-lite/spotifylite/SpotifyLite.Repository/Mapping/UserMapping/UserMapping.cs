using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Mapping.UserMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DateOfBirth).IsRequired();

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Value).HasColumnName("Email");
            });

            builder.OwnsOne(x => x.Password, p =>
            {
                p.Property(f => f.Value).HasColumnName("Password");
            });

            builder.OwnsOne(x => x.CPF, p =>
            {
                p.Property(f => f.Value).HasColumnName("CPF");
            });


        }
    }
}
