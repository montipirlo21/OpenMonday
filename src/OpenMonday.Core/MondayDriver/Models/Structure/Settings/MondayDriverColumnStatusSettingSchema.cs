using System.Text.Json.Serialization;

public class MondayDriverColumnStatusSettingSchema : MondayDriverColumnSettingSchema
{
     [JsonPropertyName("done_colors")]
    public List<int> DoneColors { get; set; }

    [JsonPropertyName("labels")]
    public Dictionary<string, string> Labels { get; set; }

    [JsonPropertyName("labels_positions_v2")]
    public Dictionary<string, int> LabelsPositionsV2 { get; set; }

    [JsonPropertyName("labels_colors")]
    public Dictionary<string, LabelColor> LabelsColors { get; set; }
}

public class LabelColor
{
    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("border")]
    public string Border { get; set; }

    [JsonPropertyName("var_name")]
    public string VarName { get; set; }
}