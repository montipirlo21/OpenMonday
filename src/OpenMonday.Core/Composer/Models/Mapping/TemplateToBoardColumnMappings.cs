public class TemplateToBoardColumnMappings
{
    public List<TemplateToBoardColumnMapping> Mapping { get; set; }

    public TemplateToBoardColumnMappings(List<TemplateToBoardColumnMapping> mapping)
    {
        Mapping = mapping;
    }

    public static TemplateToBoardColumnMappings Create(List<TemplateToBoardColumnMapping> mapping)
    {
        return new TemplateToBoardColumnMappings(mapping);
    }

    public TemplateToBoardColumnMapping GetColumnMapByName(string name)
    {
        return Mapping.Single(x => x.TemplateColumn.SearchingName.Contains(name));
    }
}
