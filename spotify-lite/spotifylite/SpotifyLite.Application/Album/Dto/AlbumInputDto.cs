using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Dto
{
    public record AlbumInputDto(string Name, string Band, string Description, string Backdrop, List<MusicInputDto> Musics);
    public record AlbumOutputDto(Guid Id, string Name, string Description, string Backdrop, string Band, List<MusicOutputDto> Musics);
    public record MusicInputDto(String Name, int Duration);
    public record MusicOutputDto(String Name, string Duration);

}