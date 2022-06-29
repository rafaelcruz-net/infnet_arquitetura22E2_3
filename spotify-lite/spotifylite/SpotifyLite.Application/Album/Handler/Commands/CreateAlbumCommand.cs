using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Commands
{
    public class CreateAlbumCommand: IRequest<CreateAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public CreateAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }

    }
}
