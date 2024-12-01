using System.Text.Json.Serialization;

public class MondayDriverTimeLineColumnData : MondayDriverBaseColumnData
{

    [JsonPropertyName("from")]
    public DateTime From { get; set; }
    [JsonPropertyName("to")]
    public DateTime To { get; set; }
    [JsonPropertyName("changed_at")]
    public DateTime Changed_At { get; set; }

    [JsonPropertyName("visualization_type")]
    public string? VisualizationType { get; set; }

    public MondayDriverTimeLineColumnData(DateTime from, DateTime to, DateTime changed_At, string? visualizationType) : base()
    {
        From = from;
        To = to;
        Changed_At = changed_At;
        VisualizationType = visualizationType;
    }

    public static MondayDriverTimeLineColumnData Create(DateTime from, DateTime to, DateTime changed_At, string? visualizationType)
    {
        return new MondayDriverTimeLineColumnData(from, to, changed_At, visualizationType);
    }


}