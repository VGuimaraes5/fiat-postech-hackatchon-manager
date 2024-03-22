using Hackathon.Manager.Api.Domain.Models;

namespace Hackathon.Manager.Api.Domain.Interfaces.Services;

public interface IEmployeeService
{
    Task CreateAsync(CreateEmployeeModel model);
}