using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MondayFileClientController : ControllerBase
{
    private readonly IMondayFileClientService _mondayFileClientService;

    public MondayFileClientController(IMondayFileClientService mondayFileClientService)
    {
        _mondayFileClientService = mondayFileClientService;
    }

    /// </summary>
    /// <param name="board_id"></param>
    /// <returns></returns>
    [HttpGet("UploadFileToColumn")]
    public async Task<ActionResult<string>> UploadFileToColumn()
    {
        long itemId = 1692625927;
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
        var result = await _mondayFileClientService.UploadFileToColumnAsync(
             itemId: itemId,
             columnId: columnId,
             fileStream: stream,
             fileName: "test-upload.txt",
             contentType: "text/plain");

        return "value";
    }
}
