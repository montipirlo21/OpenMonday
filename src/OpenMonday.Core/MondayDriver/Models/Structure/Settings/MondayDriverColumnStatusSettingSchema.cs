using System.Text.Json.Serialization;

public class MondayDriverColumnStatusSettingSchema : MondayDriverColumnSettingSchema
{
    [JsonPropertyName("labels")]
    public List<LabelColor> Labels { get; set; }
}

public class LabelColor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("color")]
    public int Color { get; set; }
    
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }
    
    [JsonPropertyName("is_done")]
    public bool Is_done { get; set; }
    
    [JsonPropertyName("is_deactivated")]
    public bool Is_deactivated { get; set; }
    
    [JsonPropertyName("hex")]
    public string Hex { get; set; }    
}