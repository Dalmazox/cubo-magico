using CuboMagico.Infra.Data.Mappings;
using CuboMagico.Infra.Data.Mappings.Relations;
using Microsoft.EntityFrameworkCore;

namespace CuboMagico.Infra.Data.Context
{
    public class CuboContext : DbContext
    {
        public CuboContext(DbContextOptions options) : base(options)
        {
        }

        // Método que o EFCore usa para configurar as entidades e chaves estrangeiras para o banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(UsuarioMap).Assembly)
                .ConfigurarForeignKeys();

            base.OnModelCreating(modelBuilder);
        }
    }
}
