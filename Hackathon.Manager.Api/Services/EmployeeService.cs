using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Domain.Interfaces.Repositories;
using Hackathon.Manager.Api.Domain.Interfaces.Services;
using Hackathon.Manager.Api.Domain.Models;

namespace Hackathon.Manager.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ICognitoService _cognitoService;
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(ICognitoService cognitoService, IEmployeeRepository employeeRepository)
    {
        _cognitoService = cognitoService;
        _employeeRepository = employeeRepository;
    }

    public async Task CreateAsync(CreateEmployeeModel model)
    {
        try
        {
            var entity = new EmployeeEntity
            {
                Name = model.Name,
                Registration = this.CreateRandonRegistration(),
                Email = model.Email,
                BirthDate = model.BirthDate,
                Cpf = model.Cpf,
            };

            var userIdentification = await _cognitoService.CreateUserAsync(entity, model.Password);

            if (string.IsNullOrEmpty(userIdentification))
                throw new InvalidOperationException("Error to create user in Cognito!");

            entity.UserIdentification = userIdentification;

            await _employeeRepository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
    }

    private string CreateRandonRegistration()
    {
        return Guid.NewGuid().ToString().Substring(0, 12).Replace("-", "").ToUpper();
    }
}