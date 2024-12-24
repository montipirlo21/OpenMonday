public class MondayDriverTimeLineColumnData : MondayDriverBaseColumnData
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? VisualizationType { get; set; }

    public MondayDriverTimeLineColumnData(DateTime? from, DateTime? to, DateTime? updatedAt, string? visualizationType) : base()
    {
        From = from;
        To = to;
        UpdatedAt = updatedAt;
        VisualizationType = visualizationType;
    }

    public static MondayDriverTimeLineColumnData Create(DateTime? from, DateTime? to, DateTime? updatedAt, string? visualizationType)
    {
        return new MondayDriverTimeLineColumnData(from, to, updatedAt, visualizationType);
    }


}