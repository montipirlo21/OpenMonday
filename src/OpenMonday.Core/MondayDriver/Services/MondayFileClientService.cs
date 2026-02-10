using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using OpenMonday.Core.MondayDriver.Services.Interfaces;
using static ServiceCollectionExtensions;

namespace OpenMonday.Core.MondayDriver.Services;

public class MondayFileClientService : IMondayFileClientService
{
    private readonly HttpClient _httpClient;
    private OpenMondayDriverOptions _openMondayDriverOptions;

    public MondayFileClientService(HttpClient httpClient, IOptions<OpenMondayDriverOptions> openMondayDriverOptions)
    {
        _httpClient = httpClient;
        _openMondayDriverOptions = openMondayDriverOptions.Value;
    }

    public async Task<string> UploadFileToColumnAsync(
    long itemId,
    string columnId,
    Stream fileStream,
    string fileName,
    string contentType,
    CancellationToken ct = default)
    {
        var query = "mutation addFile($file: File!) { add_file_to_column (item_id: " + itemId +
                    ", column_id: \"" + columnId + "\", file: $file) { id } }";

        using var form = new MultipartFormDataContent();

        // ⚠️ monday vuole STRING CONTENT senza content-type json
        form.Add(new StringContent(query), "query");

        // ⚠️ MAP DEVE ESSERE STRINGA PURA (non application/json)
        form.Add(new StringContent("{\"file\":\"variables.file\"}"), "map");

        // ⚠️ VARIABLES DEVE ESSERE STRINGA PURA
        form.Add(new StringContent("{\"file\":null}"), "variables");

        // FILE BINARIO
        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        form.Add(fileContent, "file", fileName);

        var response = await _httpClient.PostAsync("file", form, ct);
        var body = await response.Content.ReadAsStringAsync(ct);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Monday upload failed: {body}");

        return body;
    }
}
