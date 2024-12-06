using OpenMonday.Core.strawberryShake;
using StrawberryShake;


namespace OpenMonday.Tests.MondayDriver.TestBuildes;



public class TestDataBuilders_MondayDriverBoardStructure
{

    public static OperationResult<IGetBoardsStructureByIdResult> GenerateSimpleBoardResult()
    {
        string boardId = "BoardId";
        string boardName = "BoardName";
        int? item_count = 10;

        var listColumn = new List<GetBoardsStructureById_Boards_Columns_Column>(){
            new("name", "Name", ColumnType.Text, string.Empty),
            new("project_owner", "Owner", ColumnType.People,"{\"hide_footer\":false,\"max_people_allowed\":\"0\"}"),
            new("project_status", "Status", ColumnType.Status,"{\"done_colors\":[1],\"labels\":{\"0\":\"Working on it\",\"1\":\"Done\",\"2\":\"Stuck\"},\"labels_positions_v2\":{\"0\":0,\"1\":2,\"2\":1,\"5\":3},\"labels_colors\":{\"0\":{\"color\":\"#fdab3d\",\"border\":\"#e99729\",\"var_name\":\"orange\"},\"1\":{\"color\":\"#00c875\",\"border\":\"#00b461\",\"var_name\":\"green-shadow\"},\"2\":{\"color\":\"#df2f4a\",\"border\":\"#ce3048\",\"var_name\":\"red-shadow\"}}}"),
            new("date", "Due date", ColumnType.Date,string.Empty),
            new("timeline__1", "Timeline",ColumnType.Timeline,"{\"hide_footer\":false,\"show_set_as_milestone\":false}")
        };

        IGetBoardsStructureByIdResult data = new GetBoardsStructureByIdResult(new List<GetBoardsStructureById_Boards_Board>()
        {
            new(boardId, boardName, item_count, listColumn)
        });

        var operationResult = new OperationResult<IGetBoardsStructureByIdResult>(data, null, null, null, null, null);
        return operationResult;
    }
}
