using OpenMonday.Core.strawberryShake;
using StrawberryShake;

public static class TestDataBuilders_MondayDriverActivityLogs
{
    public static IOperationResult<IGetActivityLogResult> GenerateActivityLogsResult()
    {
        var activityLogs = new List<IGetActivityLog_Boards_Activity_logs>
            {
                new GetActivityLog_Boards_Activity_logs_ActivityLogType("log1", "user1", "event1", DateTime.UtcNow.ToString("o")),
                new GetActivityLog_Boards_Activity_logs_ActivityLogType("log2", "user2", "event2", DateTime.UtcNow.ToString("o"))               
            };

        var boards = new List<IGetActivityLog_Boards>
            {
                new GetActivityLog_Boards_Board("2025-01-22T08:03:58Z", activityLogs)              
            };

        var data = new GetActivityLogResult(boards);
        return new OperationResult<IGetActivityLogResult>(data, null, null, null, null);
    }

    public static IOperationResult<IGetActivityLogResult> GenerateEmptyActivityLogsResult()
    {
        var activityLogs = new List<IGetActivityLog_Boards_Activity_logs>
            {
               
            };

        var boards = new List<IGetActivityLog_Boards>
            {
                new GetActivityLog_Boards_Board("2025-01-22T08:03:58Z", activityLogs)              
            };

        var data = new GetActivityLogResult(boards);
        return new OperationResult<IGetActivityLogResult>(data, null, null, null, null);
    }
}

