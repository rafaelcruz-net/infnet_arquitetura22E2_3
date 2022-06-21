using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Infrastructure.Database;

namespace SpotifyLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public IAlbumRepository AlbumRepository { get; }

        public AlbumController(IAlbumRepository albumRepository)
        {
            AlbumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.AlbumRepository.GetAll());
        }
    }
}
