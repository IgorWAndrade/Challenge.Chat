using IWA.Challenge.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IWA.Challenge.Chat.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(x => x.Foto)
                .IsRequired(false);

            builder
                .Property(x => x.Nome)
                .IsRequired(false)
                .HasMaxLength(120);

            builder
                .Property(x => x.Apelido)
                .IsRequired(false)
                .HasMaxLength(60);

            builder
                .Property(x => x.Anonimo)
                .IsRequired(true);
        }
    }
}
