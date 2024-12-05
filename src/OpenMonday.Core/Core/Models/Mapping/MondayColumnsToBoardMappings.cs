public class MondayColumnsToBoardMappings
{
    public List<MondayColumnsToBoardMapping> Mapping { get; set; }

    public MondayColumnsToBoardMappings(List<MondayColumnsToBoardMapping> mapping)
    {
        Mapping = mapping;
    }

    public static MondayColumnsToBoardMappings Create(List<MondayColumnsToBoardMapping> mapping)
    {
        return new MondayColumnsToBoardMappings(mapping);
    }

    public MondayColumnsToBoardMapping GetColumnMapByName(string name)
    {
        return Mapping.Single(x => x.ColumnMapping.SearchingName.Contains(name));
    }
}
