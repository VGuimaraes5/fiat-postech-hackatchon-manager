using Hackathon.Manager.Api.Domain.Interfaces.Services;
using Hackathon.Manager.Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Manager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeModel model)
    {
        try
        {
            await _employeeService.CreateAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}