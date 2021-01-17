using IWA.Challenge.Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IWA.Challenge.Chat.Infra.Data.Mappings
{
    public class BaseEntidadeMap<T> : IEntityTypeConfiguration<T>
           where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
