using GPBA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GPBA.Domain.Common;

namespace GPBA.Infrastructure.DbConfiguration;

/// <summary>
/// Конфигурация БД для сущности оффера
/// </summary>
public class OfferDbConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Brand)
            .HasMaxLength(Constraints.SHORT_FIELD_LENGTH)
            .IsRequired();
        builder.Property(o => o.Model)
            .HasMaxLength(Constraints.SHORT_FIELD_LENGTH)
            .IsRequired();
        builder.Property(o => o.SupplierId)
            .IsRequired();
        builder.Property(o => o.CreatedAt)
            .HasMaxLength(Constraints.SHORT_FIELD_LENGTH)
            .IsRequired();

        builder.HasIndex(o => o.Model);
    }
}
