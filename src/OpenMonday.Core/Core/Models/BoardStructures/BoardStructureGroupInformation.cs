public class BoardStructureGroupInformation{

    public string GroupId {get; set;}
    public string Title {get; set;} 

    protected BoardStructureGroupInformation(string groupId, string title)
    {
        GroupId = groupId;
        Title = title;
    }

    public static BoardStructureGroupInformation Create(string groupId, string title)
    {
        return new BoardStructureGroupInformation(groupId, title);
    }

}