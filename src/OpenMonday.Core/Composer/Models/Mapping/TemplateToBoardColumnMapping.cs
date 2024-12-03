public class TemplateToBoardColumnMapping
{
    public string BoardColumnId { get; set; }
    public TemplateBoardColumn TemplateColumn { get; set; }
    public Type DestinationBoardType {get; set;}


    public TemplateToBoardColumnMapping(string boardColumnId, TemplateBoardColumn templateColumn, Type destinationBoardType)
    {
        BoardColumnId = boardColumnId;
        TemplateColumn = templateColumn;
        DestinationBoardType = destinationBoardType;
    }

    public static TemplateToBoardColumnMapping Create(string boardColumnId, TemplateBoardColumn templateColumn, Type destinationBoardType)
    {
        return new TemplateToBoardColumnMapping(boardColumnId, templateColumn, destinationBoardType);
    }
}
