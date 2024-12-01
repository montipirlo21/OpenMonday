using System.Text.Json.Serialization;

public class MondayDriverDateColumnData : MondayDriverBaseColumnData
{

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    
    [JsonPropertyName("changed_at")]
    public DateTime Changed_At { get; set; }

    public MondayDriverDateColumnData(DateTime date,  DateTime changed_At) : base()
    {
        Date = date;
        Changed_At = changed_At;
    }

    public static MondayDriverDateColumnData Create(DateTime date,  DateTime changed_At)
    {
        return new MondayDriverDateColumnData( date,  changed_At);
    }


}