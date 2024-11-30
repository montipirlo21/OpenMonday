using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class SimulationController : ControllerBase
{
    private readonly IMondayDriverService _mondayDriverService;

    public SimulationController(IMondayDriverService mondayDriverService)
    {
        _mondayDriverService = mondayDriverService;
    }

    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("GetBoardsStructureById")]
    public async Task<ActionResult<string>> GetBoardsStructureById([FromQuery] string boardId)
    {
        var result = await _mondayDriverService.GetBoardsStructureById(boardId);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }
}
