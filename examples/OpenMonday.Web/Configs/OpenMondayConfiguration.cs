public class OpenMondayConfiguration
{
    public string? MondayWebApiUrl { get; set; }
    public string? MondayToken { get; set; }    
    
    public OpenMondayConfiguration()
    {
        MondayWebApiUrl = null;
        MondayToken = null;
    }    
}
