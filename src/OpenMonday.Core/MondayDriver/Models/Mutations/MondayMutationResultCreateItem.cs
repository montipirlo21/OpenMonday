public class MondayMutationResultCreateItem : MondayMutationResultBaseModel
{
    public string Item_id {get; set;}

    public MondayMutationResultCreateItem(string json, string item_id) : base(json)
    {
        this.Item_id = item_id;
    }

     public static MondayMutationResultCreateItem Create(string json, string item_id)
    {
        return new MondayMutationResultCreateItem(json, item_id);
    }
}