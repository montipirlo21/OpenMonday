public class Board_StandardProject_Item : Board_Item
{
    public Board_Column_People Owner { get; set; }
    public Board_Column_Status Status { get; set; }
    public Board_Column_Timeline Timeline { get; set; }

    public Board_StandardProject_Item(){}

    public Board_StandardProject_Item(string id, string name, Board_Column_People owner, Board_Column_Status status, Board_Column_Timeline timeline) : base(id, name)
    {
        Owner = owner;
        Status = status;
        Timeline = timeline;
    }

    public static Board_StandardProject_Item Create(string id, string name, Board_Column_People owner, Board_Column_Status status, Board_Column_Timeline timeline)
    {
        return new Board_StandardProject_Item(id, name, owner, status, timeline);
    }
}
