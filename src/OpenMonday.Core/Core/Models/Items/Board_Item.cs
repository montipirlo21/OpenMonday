public class Board_Item
{
    public string ItemId { get; set; }
    public string Name { get; set; }
    public string GroupId { get; set; }

    public Board_Item(){
        
    }

    public Board_Item(string itemId, string name,string groupId )
    {
        ItemId = itemId;
        Name = name;
        GroupId = groupId;
    }

    public static Board_Item Create(string itemId, string name, string groupId)
    {
        return new Board_Item(itemId, name, groupId);
    }

    public void SetItemIdAndNameAndGroup(string itemId, string name,  string groupId){
        this.ItemId = itemId;
        this.Name = name;
        this.GroupId = groupId;
    }

}
