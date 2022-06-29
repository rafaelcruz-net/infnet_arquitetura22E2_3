using Microsoft.EntityFrameworkCore;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Infrastructure.Database;
using SpotifyLite.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Album>> GetAllAlbum()
        {
            return await Task.FromResult(this._set.Include(x => x.Musics).AsEnumerable());
        }
    }
}
