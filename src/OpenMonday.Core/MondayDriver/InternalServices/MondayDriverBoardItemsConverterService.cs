using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;

public class MondayDriverBoardItemsConverterService : IMondayDriverBoardItemsConverterService
{
    public List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_Boards_Items_page_Items> value)
    {
        throw new NotImplementedException();
    }

    public List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_NextPage_Next_items_page_Items> value)
    {
        throw new NotImplementedException();
    }
}