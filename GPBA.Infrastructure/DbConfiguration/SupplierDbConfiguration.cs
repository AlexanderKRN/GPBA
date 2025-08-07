using GPBA.Domain.Common;
using GPBA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPBA.Infrastructure.DbConfiguration;

/// <summary>
/// Конфигурация БД для сущности поставщика
/// </summary>
public class SupplierDbConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .HasMaxLength(Constraints.SHORT_FIELD_LENGTH)
            .IsRequired();
        builder.Property(s => s.CreatedAt)
            .HasMaxLength(Constraints.SHORT_FIELD_LENGTH)
            .IsRequired();

        builder.HasMany(s => s.Offers).WithOne().IsRequired();
    }
}
