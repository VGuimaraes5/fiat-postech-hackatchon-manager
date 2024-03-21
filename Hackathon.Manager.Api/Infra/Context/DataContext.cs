using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace Hackathon.Manager.Api.Infra.Context;

public class DataContext : DbContext
{
    private readonly byte[] _encryptionKey = AesProvider.GenerateKey(AesKeySize.AES128Bits).Key;
    private readonly byte[] _encryptionIV = AesProvider.GenerateKey(AesKeySize.AES128Bits).IV;
    private readonly IEncryptionProvider _encryptionProvider;

    public DbSet<EmployeeEntity>? Employee { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        _encryptionProvider = new AesProvider(this._encryptionKey, this._encryptionIV);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeMapping());

        modelBuilder.UseEncryption(_encryptionProvider);
    }
}