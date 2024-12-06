using System.Security;
using OpenMonday.Core.strawberryShake;

public class MondayDriverColumnSchema
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public MondayDriverColumnSettingSchema Settings { get; set; }

    public MondayDriverColumnSchema(string id, string title, string type, MondayDriverColumnSettingSchema settings)
    {
        Id = id;
        Title = title;
        Type = type;
        Settings = settings;
    }

    public static MondayDriverColumnSchema Create(string id, string title, string type, MondayDriverColumnSettingSchema settings)
    {
        return new MondayDriverColumnSchema(id, title, type, settings);
    }
}