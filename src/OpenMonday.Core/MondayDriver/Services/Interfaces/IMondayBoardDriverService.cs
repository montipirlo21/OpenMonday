using System.Text.Json;

namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayBoardDriverService
{
    Task<MondayDriverResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId);

    Task<MondayDriverResult<List<MondayDriverBaseTask>>> GetBoardItemsByCursor(string board_id);

    Task<MondayDriverResult<List<MondayDriverActivityLog>>> GetActivityLogs(string board_id, DateTime from, DateTime to);

    Task<MondayDriverResult<MondayMutationResultBaseModel>> UpdateBoardName(string board_id, string name);

    Task<MondayDriverResult<MondayMutationResultBaseModel>> UpdateItemName(string board_id, string item_id, string newName);

    Task<MondayDriverResult<MondayMutationResultCreateItem>> CreateItem(string board_id, string group_id, string item_name, JsonElement? columnValues);

}