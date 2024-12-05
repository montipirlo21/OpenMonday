/// <summary>
/// Object used for mapping columns from generic board to real board
/// </summary>
public class TemplateBoard
{
    public List<TemplateBoardColumn> Columns { get; set; }


    public TemplateBoard(List<TemplateBoardColumn> columns)
    {
        Columns = columns;
    }

    public static TemplateBoard Create( List<TemplateBoardColumn> columns)
    {
        return new TemplateBoard(columns);
    }
}
