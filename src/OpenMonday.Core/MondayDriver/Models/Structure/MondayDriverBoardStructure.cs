public class MondayDriverBoardStructure
{
    public string BoardId { get; set; }
    public string BoardName { get; set; }
    public List<MondayDriverColumnSchema> BoardColumns { get; set; }

    protected MondayDriverBoardStructure(string boardId, string boardName, List<MondayDriverColumnSchema> boardColumns)
    {
        this.BoardId = boardId;
        this.BoardName = boardName;
        this.BoardColumns = boardColumns;
    }

    public static MondayDriverBoardStructure Create(string id, string name, List<MondayDriverColumnSchema> boardColumns)
    {
        return new MondayDriverBoardStructure(id, name, boardColumns);
    }
}