using SpotifyLite.Application.Album.Dto;

namespace SpotifyLite.Application.Album.Services
{
    public interface IAlbumServices
    {
        Task<AlbumOutputDto> Create(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> GetAll();
    }
}