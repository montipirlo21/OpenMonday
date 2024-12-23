using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayDriverController : ControllerBase
{
    private readonly IMondayBoardDriverService _mondayBoardDriverService;

    public MondayDriverController(IMondayBoardDriverService mondayBoardDriverService)
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
}
