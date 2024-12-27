using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayUserDriverController : ControllerBase
{
    private readonly IMondayUserDriverService _mondayUserDriverService;

    public MondayUserDriverController(IMondayUserDriverService mondayUserDriverService)
    {
        _mondayUserDriverService = mondayUserDriverService;
    }

    [HttpGet("GetUsers")]
    public async Task<ActionResult<string>> GetUsers()
    {
        var teams = await _mondayUserDriverService.GetUsers();
        return Ok(teams);
    }
}
