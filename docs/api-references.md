# API References

## IBoardServices

### `RetrieveAndBuildBoard<T, TItem>(string board_id, TemplateBoard template)`
**Description:**  
This is the core method for retrieving and composing a board. It retrieves a board by its ID and builds it using the provided template. It supports generic types `T` for the board and `TItem` for the board items.

#### **Parameters:**

| Name          | Type                     | Description                                                   | Required |
|---------------|--------------------------|---------------------------------------------------------------|----------|
| `board_id`    | `string`                 | The unique ID of the board to retrieve.                       | Yes      |
| `template`    | `TemplateBoard`          | The template used to construct the board. This defines how the board's data is structured. | Yes      |

#### **Type Parameters:**

| Name      | Description                                                     |
|-----------|-----------------------------------------------------------------|
| `T`       | The type of the board (must inherit from `Board`).               |
| `TItem`   | The type of the board item (must inherit from `Board_Item`).     |

#### **Returns:**
- `Task<ServiceResult<T>>`:  
  A task that represents the asynchronous operation. The result contains the board object of type `T`.

#### **Example:**

```csharp
// Define your Items
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

// Define your board and the mapping template
// BoardMapping is a mapper
// First parameter is the property of the item to assign an object of class typeof(T) [third parameter], the second parameter is the name of the column of the board.

public class Board_StandardProject : Board
{
    public List<Board_StandardProject_Item> Items { get; set; }

    public Board_StandardProject(){
        
    }
    
    public Board_StandardProject(string id, string name, List<Board_StandardProject_Item> items) : base(id, name)
    {
        Items = items;
    }

    public static Board_StandardProject Create(string id, string name, List<Board_StandardProject_Item> items)
    {
        return new Board_StandardProject(id, name, items);
    }

    public static new TemplateBoard GetBoardTemplate(){
        
        string title = "Standard Project Board Template";
        string description = "Template structure for standard project board";
        List<TemplateBoardColumn> columnNames = new List<TemplateBoardColumn>(){
            new TemplateBoardColumn("Owner",["Owner"]),
            new TemplateBoardColumn("Status",["Status", "Stato" ]),
            new TemplateBoardColumn("Timeline",["Timeline", "Pianificazione"])
        };

        return new TemplateBoard(title, description,  columnNames);
    }
}
 


```