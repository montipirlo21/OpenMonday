using System.Text.Json;
using System.Text.Json.Serialization;
public static class JsonHelper
{

    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {     
        Converters = { new JsonStringEnumConverter() }
    };

    public static string Serialize<T>(T obj)
    {
        try
        {
            return JsonSerializer.Serialize<T>(obj, _options);
        }
        catch (Exception e)
        {
            LoggerHelper.LogException(e);
            throw;
        }
    }

    public static T? Deserialize<T>(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }
        catch (Exception e)
        {
            LoggerHelper.LogError($"Error deserializing {json}");
            LoggerHelper.LogException(e);
            throw;
        }
    }

    public static T? Deserialize<T>(JsonElement json)
    {
        try
        {
            return json.Deserialize<T>(_options);
        }
        catch (Exception e)
        {
            LoggerHelper.LogError($"Error deserializing {json}");
            LoggerHelper.LogException(e);
            throw;
        }
    }
}
