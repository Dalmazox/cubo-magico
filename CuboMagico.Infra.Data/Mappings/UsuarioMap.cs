using CuboMagico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuboMagico.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Usando FluentAPI para mapear as propriedades da entidade para o banco de dados

            // Tabela
            builder.ToTable("usuarios");

            // Chave
            builder.HasKey(x => x.ID);

            // Tipos de coluna
            builder
                .Property(x => x.Nome)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(x => x.Senha)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(x => x.Ativo)
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .IsRequired();

            // Index
            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder
                .HasIndex(x => x.DataCadastro);
        }
    }
}
