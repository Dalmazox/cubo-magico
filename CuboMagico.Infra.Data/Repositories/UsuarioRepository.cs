using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Infra.Data.Context;

namespace CuboMagico.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CuboContext context) : base(context)
        {
        }
    }
}
