using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Mapping.AlbumMapping
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).HasMaxLength(1024);
            builder.Property(x => x.ReleaseDate).IsRequired();

            builder.OwnsOne(p => p.Band, f =>
            {
                f.Property(x => x.Name).HasColumnName("BandName");
            });

            builder.HasMany(x => x.Musics).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
