# API References

## IBoardServices


### `RetrieveAndBuildBoard<T, TItem>(string board_id)`

**Description:**  
This is the core method for retrieving and composing a board. It retrieves a board by its ID and builds it using the custom attribute  It supports generic types `T` for the board and `TItem` for the board items.

#### **Parameters:**

| Name           | Type           | Description                                                                                    | Required |
| -------------- | -------------- | ---------------------------------------------------------------------------------------------- | -------- |
| `board_id`     | `string`       | The unique ID of the board to retrieve.                                                        | Yes      |

#### **Type Parameters:**

| Name    | Description                                                  |
| ------- | ------------------------------------------------------------ |
| `T`     | The type of the board (must inherit from `Board`).           |
| `TItem` | The type of the board item (must inherit from `Board_Item`). |

#### **Returns:**

- `Task<ServiceResult<T>>`:  
  A task that represents the asynchronous operation. The result contains the board object of type `T`.

#### **Example:**

```csharp
// Define your Items with the attribute ColumnMapping
public class Board_StandardProject_Item : Board_Item
{
    [ColumnMapping(searchingNames: ["Owner"] )]
    public Board_Column_People Owner { get; set; }
    [ColumnMapping(searchingNames: ["Status", "Stato"])]
    public Board_Column_Status Status { get; set; }
    [ColumnMapping(searchingNames: ["Timeline", "Pianificazione"])]
    public Board_Column_Timeline Timeline { get; set; }

    public Board_StandardProject_Item() { }

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

// Declare your board type
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
}
```

### `RetrieveAndBuildBoard<T, TItem>(string board_id, MappingBoard mappingBoard)`

**Description:**  
This is the core method for retrieving and composing a board. It retrieves a board by its ID and builds it using the provided mappingBoard. It supports generic types `T` for the board and `TItem` for the board items.

#### **Parameters:**

| Name           | Type           | Description                                                                                    | Required |
| -------------- | -------------- | ---------------------------------------------------------------------------------------------- | -------- |
| `board_id`     | `string`       | The unique ID of the board to retrieve.                                                        | Yes      |
| `mappingBoard` | `MappingBoard` | The mappingBoard used to construct the board. This defines how the board's data is structured. | Yes      |

#### **Type Parameters:**

| Name    | Description                                                  |
| ------- | ------------------------------------------------------------ |
| `T`     | The type of the board (must inherit from `Board`).           |
| `TItem` | The type of the board item (must inherit from `Board_Item`). |

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

    public Board_StandardProject_Item() { }

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
}

// Define a board mapping
// First parameter is the property of the item to assign, the second parameter is the name of the column of the board.
 List<BoardColumnMapping> columnNames = new List<BoardColumnMapping>(){
            new BoardColumnMapping("Owner",["Owner"] ),
            new BoardColumnMapping("Status",["Status", "Stato" ]),
            new BoardColumnMapping("Timeline",["Timeline", "Pianificazione"])
        };
        var boardMapping =  new BoardMapping(columnNames);

```
