using AutoMapper;
using SpotifyLite.Application.Album.Dto;
using SpotifyLite.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Services
{
    internal class AlbumServices : IAlbumServices
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumServices(IAlbumRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<AlbumOutputDto> Create(AlbumInputDto dto)
        {
            var album = this.mapper.Map<Domain.Album.Album>(dto);

            await this.albumRepository.Save(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task<List<AlbumOutputDto>> GetAll()
        {
            var album = await this.albumRepository.GetAllAlbum();

            return this.mapper.Map<List<AlbumOutputDto>>(album);
        }
    }
}
