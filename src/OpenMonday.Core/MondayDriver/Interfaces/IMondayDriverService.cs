namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayDriverService
{
    public Task<string> GetBoardsStructureById(string boardId);
}