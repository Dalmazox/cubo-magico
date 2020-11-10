using CuboMagico.Domain.Entities;
using CuboMagico.Domain.Interfaces.Repositories;
using CuboMagico.Infra.Data.Context;

namespace CuboMagico.Infra.Data.Repositories
{
    public class SoftwareRepository : Repository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(CuboContext context) : base(context)
        {
        }
    }
}
