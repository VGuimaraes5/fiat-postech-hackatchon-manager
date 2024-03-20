using Hackathon.Manager.Api.Domain.Entities;

namespace Hackathon.Manager.Api.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task CreateAsync(EmployeeEntity entity);
    Task<bool> ExistsAsync(EmployeeEntity entity);
}