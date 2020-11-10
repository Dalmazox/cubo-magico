using CuboMagico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuboMagico.Infra.Data.Mappings
{
    public class SoftwareMap : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            // Tabela
            builder.ToTable("softwares");

            // Chave
            builder.HasKey(x => x.ID);

            // Tipos de dados
            builder
                .Property(x => x.Nome)
                .HasColumnType("VARCHAR(128)")
                .IsRequired();

            builder
                .Property(x => x.Vigente)
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .IsRequired();

            // Index
            builder.HasIndex(x => x.Vigente);
            builder.HasIndex(x => x.DataCadastro);
        }
    }
}
