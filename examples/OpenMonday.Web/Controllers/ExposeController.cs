
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


    [HttpGet("RetrieveAndBuildBoard")]
    public async Task<ActionResult<string>> RetrieveAndBuildBoard([FromQuery] string board_id)
    {
        var boardBuilded = await _boardServices.RetrieveAndBuildBoard<Board_StandardProject, Board_StandardProject_Item>(board_id);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }

    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("RetrieveAndBuildBoardWithBoardMapping")]
    public async Task<ActionResult<string>> RetrieveAndBuildBoardWithBoardMapping([FromQuery] string board_id)
    {
        // Create a board mapping for the entity
        List<BoardColumnMapping> columnNames = new List<BoardColumnMapping>(){
            new BoardColumnMapping("Owner",["Owner"], true ),
            new BoardColumnMapping("Status",["Status", "Stato" ], true),
            new BoardColumnMapping("Timeline",["Timeline", "Pianificazione"], true)
        };
        var boardMapping = new BoardMapping(columnNames);

        var boardBuilded = await _boardServices.RetrieveAndBuildBoard<Board_StandardProject, Board_StandardProject_Item>(board_id, boardMapping);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }


    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("RetrieveBoardStructure")]
    public async Task<ActionResult<string>> RetrieveBoardStructure([FromQuery] string board_id)
    {
        var boardBuilded = await _boardServices.RetrieveBoardStructure(board_id);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }


    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("UpdateBoardName")]
    public async Task<ActionResult<string>> UpdateBoardName([FromQuery] string board_id, string newName)
    {
        var boardBuilded = await _boardServices.UpdateBoardName(board_id, newName);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }  
    
    /// <summary>
    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("UpdateItemName")]
    public async Task<ActionResult<string>> UpdateItemName([FromQuery] string board_id, string item_id, string newName)
    {
        var boardBuilded = await _boardServices.UpdateItemName(board_id, item_id, newName);
        return Ok($"{JsonHelper.Serialize(boardBuilded)}");
    }  
}
