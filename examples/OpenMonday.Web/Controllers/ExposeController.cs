
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
    [HttpGet("RetrieveAndBuildBoard")]
    public async Task<ActionResult<string>> RetrieveAndBuildBoard([FromQuery] string board_id)
    {
        var boardMapping = Board_StandardProject.GetBoardMapping();      
        var boardBuilded = await _boardServices.RetrieveAndBuildBoard<Board_StandardProject, Board_StandardProject_Item >(board_id,boardMapping);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }   


     [HttpGet("RetrieveAndBuildBoardWithMappingAttribute")]
    public async Task<ActionResult<string>> RetrieveAndBuildBoardWithMappingAttribute([FromQuery] string board_id)
    {   
        var boardBuilded = await _boardServices.RetrieveAndBuildBoardWithMappingAttribute<Board_StandardProject, Board_StandardProject_Item >(board_id);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }   
}
