using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Query
{
    public class GetAllQueryCommand : IRequest<GetAllQueryCommandResponse>
    {

    }

    public class GetAllQueryCommandResponse
    {
        public List<AlbumOutputDto> Albums { get; set; }

        public GetAllQueryCommandResponse()
        {

        }

        public GetAllQueryCommandResponse(List<AlbumOutputDto> albuns)
        {
            this.Albums = albuns;
        }
    }
}
