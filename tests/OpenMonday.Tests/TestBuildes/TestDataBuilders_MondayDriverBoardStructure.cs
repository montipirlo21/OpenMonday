using System.Text.Json;
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

        var statusSettings = new
        {
            labels = new[]
            {
                new
                {
                    id = 0,
                    color = 0,
                    label = "In svolgimento",
                    index = 0,
                    is_done = false,
                    is_deactivated = false,
                    hex = "#fdab3d"
                }
            }
        };

        var dropDownSettings = new
        {
            labels = new[]
            {
                new { id = 1, label = "Altre Compagnie", is_deactivated = false },
                new { id = 2, label = "Commerciale", is_deactivated = false },
                new { id = 3, label = "Prodotti Fortech", is_deactivated = false },
                new { id = 4, label = "Sviluppi Interni", is_deactivated = false },
                new { id = 5, label = "Eni", is_deactivated = false },
                new { id = 6, label = "Elettrico", is_deactivated = false },
                new { id = 7, label = "Payments", is_deactivated = false },
                new { id = 8, label = "Estero", is_deactivated = false },
                new { id = 9, label = "Sviluppi interni", is_deactivated = false },
                new { id = 10, label = "Reservation", is_deactivated = false },
                new { id = 11, label = "Piccole Evolutive", is_deactivated = false },
                new { id = 12, label = "Compagnia", is_deactivated = false },
                new { id = 13, label = "Team Board", is_deactivated = false }
            }
        };

        var listColumn = new List<GetBoardsStructureById_Boards_Columns_Column>(){
            new("name", "Name", ColumnType.Text, JsonHelper.SerializeObjToJsonElement(string.Empty)),
            new("project_owner", "Owner", ColumnType.People,JsonHelper.SerializeObjToJsonElement(string.Empty)),
            new("project_status", "Status", ColumnType.Status,JsonHelper.SerializeObjToJsonElement(statusSettings)),
            new("date", "Due date", ColumnType.Date,JsonHelper.SerializeObjToJsonElement(string.Empty)),
            new("timeline__1", "Timeline",ColumnType.Timeline,JsonHelper.SerializeObjToJsonElement(string.Empty)),
            new("dropdown", "Timeline",ColumnType.Dropdown,JsonHelper.SerializeObjToJsonElement(dropDownSettings))
        };

        var groups = new List<GetBoardsStructureById_Boards_Groups_Group>(){
            new GetBoardsStructureById_Boards_Groups_Group("Group 1","11111111111"),
            new GetBoardsStructureById_Boards_Groups_Group("Group 2","22222222222")
        };

        IGetBoardsStructureByIdResult data = new GetBoardsStructureByIdResult(new List<GetBoardsStructureById_Boards_Board>()
        {
            new(boardId, boardName, "2025-01-22T08:03:58Z", item_count, listColumn, groups)
        });

        var operationResult = new OperationResult<IGetBoardsStructureByIdResult>(data, null, null, null, null, null);
        return operationResult;
    }

    public static GetBoardsStructureById_Boards_Columns_Column GenerateStatusColumnResult()
    {
        return new("project_status", "Status", ColumnType.Status,

                   JsonHelper.SerializeObjToJsonElement(new
                   {
                       labels = new[]
                        {
                            new
                            {
                                id = 0,
                                color = 0,
                                label = "In svolgimento",
                                index = 0,
                                is_done = false,
                                is_deactivated = false,
                                hex = "#fdab3d"
                            }
                        }
                   }));
    }
}
