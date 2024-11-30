namespace OpenMonday.Core.MondayDriver.Interfaces;

public interface IMondayDriverService
{
    public  Task<MondayDriverResult<MondayDriverBoardStructure>> GetBoardsStructureById(string boardId);
}