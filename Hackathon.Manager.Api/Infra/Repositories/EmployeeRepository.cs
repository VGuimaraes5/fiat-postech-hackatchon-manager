using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Domain.Interfaces.Repositories;
using Hackathon.Manager.Api.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Manager.Api.Infra.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;
    private readonly DbSet<EmployeeEntity> _dbSet;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<EmployeeEntity>();
    }

    public async Task CreateAsync(EmployeeEntity entity)
    {
        entity.CreatedAt = DateTime.Now;

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(EmployeeEntity entity)
    {
        var result = await _dbSet.FirstOrDefaultAsync(
            x => x.Cpf.ToString() == entity.Cpf.ToString() ||
            x.Email == entity.Email ||
            x.Registration == entity.Registration);

        return result != null;
    }
}