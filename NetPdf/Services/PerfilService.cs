using Microsoft.EntityFrameworkCore;
using NetPdf.Context;
using NetPdf.DTOS;

namespace NetPdf.Services
{
    public class PerfilService
    {
        private readonly AppDbContext _context;
        public PerfilService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PerfilDTO>> lista()
        {
            var listaDTO = new List<PerfilDTO>();

            foreach (var item in await _context.Perfiles.ToListAsync())
            {
                listaDTO.Add(new PerfilDTO
                {
                    idPerfil = item.idPerfil,
                    Nombre = item.Nombre,
                });
            }

            return listaDTO;

        }

    }
}