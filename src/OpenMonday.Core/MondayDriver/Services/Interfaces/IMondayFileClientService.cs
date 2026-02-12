using System;

namespace OpenMonday.Core.MondayDriver.Services.Interfaces;

public interface IMondayFileClientService
{
    public  Task<string> UploadFileToColumnAsync(
    long itemId,
    string columnId,
    Stream fileStream,
    string fileName,
    string contentType,
    CancellationToken ct = default);
}
