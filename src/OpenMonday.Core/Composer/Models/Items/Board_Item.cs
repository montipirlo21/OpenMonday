public class Board_Item
{
    public string ItemId { get; set; }
    public string Name { get; set; }

    public Board_Item(){
        
    }

    public Board_Item(string itemId, string name)
    {
        ItemId = itemId;
        Name = name;
    }

    public static Board_Item Create(string itemId, string name)
    {
        return new Board_Item(itemId, name);
    }

    public void SetItemIdAndName(string itemId, string name){
        this.ItemId = itemId;
        this.Name = name;
    }

}
