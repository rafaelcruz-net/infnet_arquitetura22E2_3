using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.Album.Dto;
using SpotifyLite.Application.Album.Handler.Commands;
using SpotifyLite.Application.Album.Handler.Query;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Infrastructure.Database;

namespace SpotifyLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "user-policy")]
    public class AlbumController : ControllerBase
    {
        public IMediator Handler { get; }

        public AlbumController(IMediator handler)
        {
            Handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlbumInputDto inputDto)
        {
            var result = await this.Handler.Send(new CreateAlbumCommand(inputDto));

            return Created($"/{result.Album.Id}", result.Album);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Handler.Send(new GetAllQueryCommand());

            return Ok(result.Albums);
        }

    }
}
