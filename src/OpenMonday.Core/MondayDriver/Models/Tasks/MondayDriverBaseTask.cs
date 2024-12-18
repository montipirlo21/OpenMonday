public class MondayDriverBaseTask
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string GroupId { get; set; }

    public List<MondayDriverBaseColumn> Columns { get; set; }

    protected MondayDriverBaseTask(string id, string name, string groupId,  List<MondayDriverBaseColumn> columns)
    {
        this.Id = id;
        this.Name = name;
        this.GroupId = groupId;
        this.Columns = columns;
    }

    public static MondayDriverBaseTask Create(string id, string name, string groupId, List<MondayDriverBaseColumn> columns)
    {
        return new MondayDriverBaseTask(id, name, groupId, columns);
    }

    public MondayDriverBaseColumn? GetColumnById(string ownerMappingColumnId)
    {
        return Columns.FirstOrDefault(c => c.Id == ownerMappingColumnId );
    }
}