using Hackathon.Manager.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Manager.Api.Infra.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder
            .ToTable("tb_employee");

        builder.HasKey(p => p.Id);

        builder
            .HasIndex(p => p.Email)
            .IsUnique();

        builder
            .HasIndex(p => p.Cpf)
            .IsUnique();

        builder
            .HasIndex(p => p.Registration)
            .IsUnique();

        builder
            .HasIndex(p => p.UserIdentification)
            .IsUnique();

        builder.Property(p => p.Cpf)
               .HasColumnType("varchar(11)")
               .HasConversion<string>(
                    coreValue => coreValue.ToString(),
                    efValue => efValue
                );
    }
}