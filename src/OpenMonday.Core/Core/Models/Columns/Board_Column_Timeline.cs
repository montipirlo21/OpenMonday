public class Board_Column_Timeline : Board_Column_Base
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public DateTime? ChangedAt { get; set; }
    public string? VisualizationType { get; set; }

    public Board_Column_Timeline(BoardColumnFillStatus fillStatus, DateTime? from, DateTime? to, DateTime? changedAt, string? visualizationType) : base(fillStatus)
    {
        From = from;
        To = to;
        ChangedAt = changedAt;
        VisualizationType = visualizationType;
    }

    public static Board_Column_Timeline Create(DateTime from, DateTime to, DateTime changedAt, string? visualizationType)
    {
        return new Board_Column_Timeline(BoardColumnFillStatus.Filled, from, to, changedAt, visualizationType);
    }

    public static Board_Column_Timeline Create_Unfilled()
    {
        return new Board_Column_Timeline(BoardColumnFillStatus.UnFilled, null, null, null, null);
    }

    public bool ScheduledOnThisTimeRanged(DateTime start, DateTime end)
    {
        // Not filled
        if (!IsFilled())
        {
            return false;
        }

        // Filled but both null
        if (From == null && To == null)
            return false;

        // Filled but only from not null
        if (From != null && To == null)
            return From.Value >= start && From.Value <= end;

        // Filled but only to not null
        if (From == null && To != null)
            return To.Value >= start && To.Value <= end;

        // // Filled, check overlapping
        return From.Value <= end && To.Value >= start;
    }

    public bool EndingOnThisTimeRanged(DateTime start, DateTime end)
    {
         // Not filled
        if (!IsFilled())
        {
            return false;
        }

        // Check if To is defined
        if (To.HasValue)
        {
            // Is beetween end and start
            return To.Value >= start && To.Value <= end;
        }

        return false;
    }
}