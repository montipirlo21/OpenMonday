
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ExposeController : ControllerBase
{
    private readonly IBoardServices _boardServices;


    public ExposeController(IBoardServices boardServices)
    {
        _boardServices = boardServices;
    }

    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("BuildBoard")]
    public async Task<ActionResult<string>> BuildBoard([FromQuery] string board_id)
    {
        var template = Board_StandardProject.GetBoardTemplate();      
        var boardBuilded = await _boardServices.RetrieveAndBuildBoard<Board_StandardProject, Board_StandardProject_Item >(board_id,template);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }   
}
