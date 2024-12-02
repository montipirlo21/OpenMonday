using System.Text.Json;
using OpenMonday.Core.strawberryShake;
using StrawberryShake;


namespace OpenMonday.Tests.MondayDriver.TestBuildes;


public class TestDataBuilders_MondayDriverBoardItems
{
    public static OperationResult<IGetBoardItemsByCursorResult> GenerateSimpleBoardItemsByCursorResult_Empty()
    {
        List<GetBoardItemsByCursor_Boards_Board> b = new List<GetBoardItemsByCursor_Boards_Board> { };

        IGetBoardItemsByCursorResult data = new GetBoardItemsByCursorResult(b);
        var operationResult = new OperationResult<IGetBoardItemsByCursorResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static OperationResult<IGetBoardItemsByCursorResult> GenerateSimpleBoardItemsByCursorResult_Two()
    {
        List<GetBoardItemsByCursor_Boards_Board> b = new List<GetBoardItemsByCursor_Boards_Board>{

            new GetBoardItemsByCursor_Boards_Board(null),
            new GetBoardItemsByCursor_Boards_Board(null)
        };

        IGetBoardItemsByCursorResult data = new GetBoardItemsByCursorResult(b);
        var operationResult = new OperationResult<IGetBoardItemsByCursorResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static OperationResult<IGetBoardItemsByCursorResult> GenerateSimpleBoardItemsByCursorResult_Success()
    {
        List<IGetBoardItemsByCursor_Boards_Items_page_Items> tasks = GenerateIGetBoardItemsByCursor_Boards_Items_page_Items();

        List<GetBoardItemsByCursor_Boards_Board> b = new List<GetBoardItemsByCursor_Boards_Board> {

            new GetBoardItemsByCursor_Boards_Board(
                new GetBoardItemsByCursor_Boards_Items_page_ItemsResponse(null, tasks)
            )
         };

        IGetBoardItemsByCursorResult data = new GetBoardItemsByCursorResult(b);
        var operationResult = new OperationResult<IGetBoardItemsByCursorResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static List<IGetBoardItemsByCursor_Boards_Items_page_Items> GenerateIGetBoardItemsByCursor_Boards_Items_page_Items()
    {
        return new List<IGetBoardItemsByCursor_Boards_Items_page_Items>(){

            // ITEM 1
            new GetBoardItemsByCursor_Boards_Items_page_Items_Item
            ("1626989663", "Task 1",
            new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                 JsonDocument.Parse("{\"changed_at\":\"2023-08-23T12:42:09.066Z\",\"personsAndTeams\":[{\"id\":66019177,\"kind\":\"person\"}]}").RootElement,

                ColumnType.People, "cayayam389@janfab.com","PeopleValue")

            }),

            // ITEM 2
            new GetBoardItemsByCursor_Boards_Items_page_Items_Item("1626989661", "Task 2",
             new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                null, ColumnType.People, "","PeopleValue")

            }),

            // ITEM 3       
            new GetBoardItemsByCursor_Boards_Items_page_Items_Item("1626989662", "Task 3",  new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                null, ColumnType.People, "","PeopleValue")

            })
        };
    }

    public static OperationResult<IGetBoardItemsByCursorResult> GenerateSimpleBoardItemsByCursorResult_WithCursor_Success()
    {
        List<IGetBoardItemsByCursor_Boards_Items_page_Items> tasks = GenerateIGetBoardItemsByCursor_Boards_Items_page_Items();

        List<GetBoardItemsByCursor_Boards_Board> b = new List<GetBoardItemsByCursor_Boards_Board> {

            new GetBoardItemsByCursor_Boards_Board(
                new GetBoardItemsByCursor_Boards_Items_page_ItemsResponse("cursor", tasks)
            )
         };

        IGetBoardItemsByCursorResult data = new GetBoardItemsByCursorResult(b);
        var operationResult = new OperationResult<IGetBoardItemsByCursorResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static OperationResult<IGetBoardItemsByCursor_NextPageResult> GenerateSimpleBoardItemsByCursor_NextPageResultResult_Success()
    {
        List<IGetBoardItemsByCursor_NextPage_Next_items_page_Items> tasks = GenerateIGetBoardItemsByCursor_Boards__NextPageResult_Items_page_Items();

        GetBoardItemsByCursor_NextPage_Next_items_page_ItemsResponse b = new GetBoardItemsByCursor_NextPage_Next_items_page_ItemsResponse(null, tasks);

        IGetBoardItemsByCursor_NextPageResult data = new GetBoardItemsByCursor_NextPageResult(b);
        var operationResult = new OperationResult<IGetBoardItemsByCursor_NextPageResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static List<IGetBoardItemsByCursor_NextPage_Next_items_page_Items> GenerateIGetBoardItemsByCursor_Boards__NextPageResult_Items_page_Items()
    {
        return new List<IGetBoardItemsByCursor_NextPage_Next_items_page_Items>(){

            // ITEM 1
            new GetBoardItemsByCursor_NextPage_Next_items_page_Items_Item
            ("1626989663", "Task 1",
            new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                 JsonDocument.Parse("{\"changed_at\":\"2023-08-23T12:42:09.066Z\",\"personsAndTeams\":[{\"id\":66019177,\"kind\":\"person\"}]}").RootElement,

                ColumnType.People, "cayayam389@janfab.com","PeopleValue")

            }),

            // ITEM 2
            new GetBoardItemsByCursor_NextPage_Next_items_page_Items_Item("1626989661", "Task 2",
             new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                null, ColumnType.People, "","PeopleValue")

            }),

            // ITEM 3       
            new GetBoardItemsByCursor_NextPage_Next_items_page_Items_Item("1626989662", "Task 3",  new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>(){

                new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
                null, ColumnType.People, "","PeopleValue")

            })
        };
    }

    

}
