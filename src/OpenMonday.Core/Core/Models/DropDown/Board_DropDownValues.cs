namespace OpenMonday.Core.Core.Models.DropDown
{
    public class Board_DropDownValues
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public Board_DropDownValues(string id, string label)
        {
            Id = id;
            Label = label;
        }

        public static Board_DropDownValues Create(string id, string label)
        {
            return new Board_DropDownValues(id, label);
        }
    }
}