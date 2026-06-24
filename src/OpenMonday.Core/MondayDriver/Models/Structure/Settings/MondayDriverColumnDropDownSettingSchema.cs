using System.Text.Json.Serialization;

public class MondayDriverColumnDropDownSettingSchema : MondayDriverColumnSettingSchema
{
    [JsonPropertyName("labels")]
    public List<MondayDriverColumnDropDownSettingSchemaLabels> Labels { get; set; }
}

public class MondayDriverColumnDropDownSettingSchemaLabels 
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("is_deactivated")]
    public bool Is_deactivated { get; set; }    
}