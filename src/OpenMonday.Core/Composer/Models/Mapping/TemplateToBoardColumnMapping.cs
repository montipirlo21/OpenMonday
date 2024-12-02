public class TemplateToBoardColumnMapping
{
    public string BoardColumnId { get; set; }
    public TemplateBoardColumn TemplateColumn { get; set; }

    public TemplateToBoardColumnMapping(string boardColumnId, TemplateBoardColumn templateColumn)
    {
        BoardColumnId = boardColumnId;
        TemplateColumn = templateColumn;
    }

    public static TemplateToBoardColumnMapping Create(string boardColumnId, TemplateBoardColumn templateColumn)
    {
        return new TemplateToBoardColumnMapping(boardColumnId, templateColumn);
    }
}
