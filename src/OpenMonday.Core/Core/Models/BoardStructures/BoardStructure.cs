public class BoardStructure
{
    public string BoardId { get; set; }
    public string BoardName { get; set; }
    public int? ItemsCount { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<BoardStructureColumnSchema> BoardColumns { get; set; }
    public List<BoardStructureGroupInformation> Groups { get; set; }

    protected BoardStructure(string boardId, string boardName, int? itemsCount, DateTime? updatedAt,
     List<BoardStructureColumnSchema> boardColumns, List<BoardStructureGroupInformation> groups)
    {
        this.BoardId = boardId;
        this.BoardName = boardName;
        this.UpdatedAt = updatedAt;
        this.ItemsCount = itemsCount;
        this.BoardColumns = boardColumns;
        this.Groups = groups;
    }

    public static BoardStructure Create(string id, string name, int? itemsCount, DateTime? updatedAt,
     List<BoardStructureColumnSchema> boardColumns, List<BoardStructureGroupInformation> groups)
    {
        return new BoardStructure(id, name, itemsCount, updatedAt, boardColumns, groups);
    }
}