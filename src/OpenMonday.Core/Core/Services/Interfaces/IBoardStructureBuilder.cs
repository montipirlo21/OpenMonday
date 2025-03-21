public interface IBoardStructureBuilder
{
    public Task<ServiceResult<BoardStructure>> BuildBoardStructure(MondayDriverBoardStructure schema);
}