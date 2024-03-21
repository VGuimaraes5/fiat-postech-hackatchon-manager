using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Infra.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
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

        builder
            .Property(p => p.Email)
            .IsEncrypted();

        builder
            .Property(p => p.Cpf)
            .IsEncrypted();

        builder
            .Property(p => p.Name)
            .IsEncrypted();
    }
}