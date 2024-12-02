/// <summary>
/// Object used for mapping columns from generic board to real board
/// </summary>
public class TemplateBoard
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<TemplateBoardColumn> Columns { get; set; }


    public TemplateBoard(string title, string description, List<TemplateBoardColumn> columns)
    {
        Title = title;
        Description = description;
        Columns = columns;
    }

    public static TemplateBoard Create(string title, string description,  List<TemplateBoardColumn> columns)
    {
        return new TemplateBoard(title, description,  columns);
    }
}
