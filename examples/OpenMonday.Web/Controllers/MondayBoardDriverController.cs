using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayBoardDriverController : ControllerBase
{
    private readonly IMondayBoardDriverService _mondayBoardDriverService;
    private readonly IMondayFileClientService _mondayFileClientService;

    public MondayBoardDriverController(IMondayBoardDriverService mondayBoardDriverService, IMondayFileClientService mondayFileClientService)
    {
        _mondayBoardDriverService = mondayBoardDriverService;
        _mondayFileClientService = mondayFileClientService;
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

    /// <summary>
    /// </summary>
    /// <param name="boardId"></param>
    /// <returns></returns>
    [HttpGet("UpdateBoardName")]
    public async Task<ActionResult<string>> UpdateBoardName([FromQuery] string boardId, string newName)
    {
        var result = await _mondayBoardDriverService.UpdateBoardName(boardId, newName);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }

    /// <summary>
    /// </summary>
    /// <param name="boardId"></param>
    /// <returns></returns>
    [HttpGet("CreateItem")]
    public async Task<ActionResult<string>> CreateItem()
    {
        string board_id = "1626989647";
        string group_id = "1730823435_sadasd_1730823415__1";
        string item_name = "Nome Item";
        var columnValuesObject = new
        {
            text_mm0fraqx = "Hello world",
        };

        // 1️⃣ serializzi oggetto -> JSON
        string innerJson = JsonSerializer.Serialize(columnValuesObject);

        // 2️⃣ serializzi di nuovo -> STRING JSON escaped
        string doubleSerialized = JsonSerializer.Serialize(innerJson);

        // 3️⃣ converti in JsonElement
        JsonElement columnValues = JsonDocument.Parse(doubleSerialized).RootElement;

        var result = await _mondayBoardDriverService.CreateItem(board_id, group_id, item_name, columnValues);
        return Ok($"{JsonSerializer.Serialize(result)}");
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpGet("CreateItemAndUpdateFile")]
    public async Task<ActionResult<string>> CreateItemAndUpdateFile()
    {
        string board_id = "1626989647";
        string group_id = "1730823435_sadasd_1730823415__1";
        string item_name = "Nome Item";
        var columnValuesObject = new
        {
            text_mm0fraqx = "Hello world",
        };

        // 1️⃣ serializzi oggetto -> JSON
        string innerJson = JsonSerializer.Serialize(columnValuesObject);

        // 2️⃣ serializzi di nuovo -> STRING JSON escaped
        string doubleSerialized = JsonSerializer.Serialize(innerJson);

        // 3️⃣ converti in JsonElement
        JsonElement columnValues = JsonDocument.Parse(doubleSerialized).RootElement;

        var result = await _mondayBoardDriverService.CreateItem(board_id, group_id, item_name, columnValues);

        long itemId = Convert.ToInt64(result.Data.Item_id);
        string columnId = "file_mm0etk1k";

        var text = $"""
    File generato in memoria
    Data: {DateTime.UtcNow}
    Applicazione: Monday integration
    """;

        // 1️⃣ Convertiamo il testo in byte[]
        var bytes = Encoding.UTF8.GetBytes(text);

        // 2️⃣ Creiamo uno stream in memoria
        using var stream = new MemoryStream(bytes);

        // 3️⃣ Chiamiamo il metodo di upload
        var res = await _mondayFileClientService.UploadFileToColumnAsync(
             itemId: itemId,
             columnId: columnId,
             fileStream: stream,
             fileName: "test-upload.txt",
             contentType: "text/plain");


        return Ok($"{JsonSerializer.Serialize(res)}");
    }
}
