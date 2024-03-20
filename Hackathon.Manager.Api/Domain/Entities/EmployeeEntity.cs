using Hackathon.Manager.Api.Domain.Entities.Base;
using Hackathon.Manager.Api.Domain.ValueObjects;

namespace Hackathon.Manager.Api.Domain.Entities;

public class EmployeeEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string Registration { get; set; }
    public required string Email { get; set; }
    public required DateTime BirthDate { get; set; }
    public required CpfVO Cpf { get; set; }
    public string? UserIdentification { get; set; }
}