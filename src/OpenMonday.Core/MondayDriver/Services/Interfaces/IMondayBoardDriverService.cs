namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayBoardDriverService
{
    Task<MondayDriverResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId);

    Task<MondayDriverResult<List<MondayDriverBaseTask>>> GetBoardItemsByCursor(string board_id);

    Task<MondayDriverResult<List<MondayDriverActivityLog>>> GetActivityLogs(string board_id, DateTime from, DateTime to);

    Task<MondayDriverResult<MondayMutationBaseModel>> UpdateBoardName(string board_id, string name);
}