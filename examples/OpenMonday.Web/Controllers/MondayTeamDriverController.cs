using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayTeamDriverController : ControllerBase
{
    private readonly IMondayTeamDriverService _mondayTeamDriverService;

    public MondayTeamDriverController(IMondayTeamDriverService mondayTeamDriverService)
    {
        _mondayTeamDriverService = mondayTeamDriverService;
    }

    [HttpGet("GetTeams")]
    public async Task<ActionResult<string>> GetTeams()
    {
        var teams = await _mondayTeamDriverService.GetTeams();
        return Ok(teams);
    }

    /// <summary>
    /// </summary>
    /// <param name="team_id">13118233</param>
    /// <returns></returns>
    [HttpGet("GetTeamByIds")]
    public async Task<ActionResult<string>> GetTeamByIds(
         [FromQuery] string team_id)
    {
        var teams = await _mondayTeamDriverService.GetTeamByIds(team_id);
        return Ok(teams);
    }
}
