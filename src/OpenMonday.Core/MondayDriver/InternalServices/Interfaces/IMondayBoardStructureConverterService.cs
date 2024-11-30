using OpenMonday.Core.strawberryShake;

namespace OpenMonday.Core.MondayDriver.InternalServices.Interfaces
{
    public interface IMondayBoardStructureConverterService
    {
        MondayDriverBoardStructure Convert_GetBoardsStructureById_MondayDriverBoardStructure(IGetBoardsStructureById_Boards obj);
    }
}