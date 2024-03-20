using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Manager.Api.Infra.Context;

public class DataContext : DbContext
{
    public DbSet<EmployeeEntity>? Product { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeMapping());
    }
}