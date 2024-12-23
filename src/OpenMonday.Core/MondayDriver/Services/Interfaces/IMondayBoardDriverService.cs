namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayBoardDriverService
{
    Task<MondayDriverResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId);

    Task<MondayDriverResult<List<MondayDriverBaseTask>>> GetBoardItemsByCursor(string board_id);
}