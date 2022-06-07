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
    public class UserFavoriteMusicMapping : IEntityTypeConfiguration<UserFavoriteMusic>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteMusic> builder)
        {
            builder.ToTable("UserFavoriteMusics");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Music).WithMany();
            builder.HasOne(x => x.User).WithMany(x => x.FavoriteMusics);

        }
    }
}
