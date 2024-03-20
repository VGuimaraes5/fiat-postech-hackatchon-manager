using Hackathon.Manager.Api.Domain.Entities;

namespace Hackathon.Manager.Api.Domain.Interfaces.Services;

public interface ICognitoService
{
    Task<string> CreateUserAsync(EmployeeEntity employee, string password);
}