using CuboMagico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CuboMagico.Infra.Data.Mappings.Relations
{
    public static class ForeignKeyMap
    {
        public static void ConfigurarForeignKeys(this ModelBuilder builder)
        {
            builder
                .Entity<Software>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.Softwares)
                .HasForeignKey(s => s.UsuarioID);

            // Mapeamento feito acima
            //builder
            //    .Entity<Usuario>()
            //    .HasMany(u => u.Softwares)
            //    .WithOne(s => s.Usuario)
            //    .HasForeignKey(s => s.UsuarioID);
        }
    }
}
