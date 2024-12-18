public class MondayDriverGroupInformation{

    public string GroupId {get; set;}
    public string Title {get; set;} 

    protected MondayDriverGroupInformation(string groupId, string title)
    {
        GroupId = groupId;
        Title = title;
    }

    public static MondayDriverGroupInformation Create(string groupId, string title)
    {
        return new MondayDriverGroupInformation(groupId, title);
    }

}