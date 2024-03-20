namespace Hackathon.Manager.Api.Domain.Models;

public class CreateEmployeeModel
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Cpf { get; set; }
    public required string Password { get; set; }
}