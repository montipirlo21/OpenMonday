using OpenMonday.Core.strawberryShake;

namespace OpenMonday.Core.MondayDriver.InternalServices.Interfaces
{
    public interface IMondayDriverBoardItemsConverterService
    {
        List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_Boards_Items_page_Items> value);

         List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_NextPage_Next_items_page_Items> value);
    }
}