
public class MondayDriverStatusValueColumnData : MondayDriverBaseColumnData
{
    public string Text { get; set; }
    public int? Index { get; set; }
    public bool? IsDone { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UpdatedId { get; set; }

    public MondayDriverStatusValueColumnData(string text, int? index, bool? isDone, DateTime? updatedAt, string updatedId)
    {
        Text = text;
        Index = index;
        IsDone = isDone;
        UpdatedAt = updatedAt;
        UpdatedId = updatedId;
    }

    public static MondayDriverStatusValueColumnData Create(string text,int? index, bool? isDone, DateTime? updatedAt, string updatedId)
    {
        return new MondayDriverStatusValueColumnData(text, index, isDone, updatedAt, updatedId);
    }
}
