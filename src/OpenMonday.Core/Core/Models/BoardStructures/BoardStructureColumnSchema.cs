public class BoardStructureColumnSchema
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public BoardStructureColumnSchemaSetting Settings { get; set; }

    public BoardStructureColumnSchema(string id, string title, string type, BoardStructureColumnSchemaSetting settings)
    {
        Id = id;
        Title = title;
        Type = type;
        Settings = settings;
    }

    public static BoardStructureColumnSchema Create(string id, string title, string type, BoardStructureColumnSchemaSetting settings)
    {
        return new BoardStructureColumnSchema(id, title, type, settings);
    }
}