using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayBoardDriverController : ControllerBase
{
    private readonly IMondayBoardDriverService _mondayBoardDriverService;

    public MondayBoardDriverController(IMondayBoardDriverService mondayBoardDriverService)
    {
        _mondayBoardDriverService = mondayBoardDriverService;
    }

    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("GetBoardsStructureById")]
    public async Task<ActionResult<string>> GetBoardsStructureById([FromQuery] string boardId)
    {
        var result = await _mondayBoardDriverService.GetBoardsStructureById(boardId);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }

    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("GetBoardItemsByCursor")]
    public async Task<ActionResult<string>> GetBoardItemsByCursor([FromQuery] string boardId)
    {
        var result = await _mondayBoardDriverService.GetBoardItemsByCursor(boardId);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }

     /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("GetActivityLogs")]
    public async Task<ActionResult<string>> GetActivityLogs([FromQuery] string boardId, DateTime from, DateTime to)
    {
        var result = await _mondayBoardDriverService.GetActivityLogs(boardId, from, to);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }
}
