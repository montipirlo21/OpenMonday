public class Board_StandardProject_Item : Board_Item
{
    [ColumnMapping(searchingNames: ["Owner"] )]
    public Board_Column_People Owner { get; set; }
    [ColumnMapping(searchingNames: ["Status", "Stato"])]
    public Board_Column_Status Status { get; set; }
    [ColumnMapping(searchingNames: ["Timeline", "Pianificazione"])]
    public Board_Column_Timeline Timeline { get; set; }
    [ColumnMapping(searchingNames: ["Priority"])]
    public Board_Column_String_Value? Priority { get; set; }

    public Board_StandardProject_Item() { }

    public Board_StandardProject_Item(string id, string name, string groupid, Board_Column_People owner, Board_Column_Status status, 
    Board_Column_Timeline timeline, Board_Column_String_Value? priority) : 
    base(id, name, groupid)
    {
        Owner = owner;
        Status = status;
        Timeline = timeline;
        Priority = priority;
    }

    public static Board_StandardProject_Item Create(string id, string name,string groupid, Board_Column_People owner, Board_Column_Status status,
     Board_Column_Timeline timeline, Board_Column_String_Value? priority)
    {
        return new Board_StandardProject_Item(id, name, groupid, owner, status, timeline, priority);
    }
}
