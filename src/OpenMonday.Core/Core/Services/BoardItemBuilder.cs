
using OpenMonday.Core.strawberryShake;

public class BoardItemBuilder : IBoardItemBuilder
{
    public Dictionary<string, Board_Column_Base> GenericItemBuilders(TemplateToBoardColumnMappings columnMapping, MondayDriverBaseTask task)
    {
        if (columnMapping == null || task == null)
        {
            throw new NullReferenceException("columnMapping == null || tasks == null");
        }

        try
        {
            // Generic building 
            var buildedDict = GenericItemBuilder(columnMapping, task).ToDictionary(x => x.Item1, x => x.Item2); ;

            // Object from configuration
            return buildedDict;
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            LoggerHelper.Log($"MondayBaseTask {JsonHelper.Serialize(task)}");
            throw;
        }
    }

    private List<(string, Board_Column_Base)> GenericItemBuilder(TemplateToBoardColumnMappings columnMapping, MondayDriverBaseTask tasks)
    {
        // Scripted logic, reword needed here
        List<(string, Board_Column_Base)> builded = new List<(string, Board_Column_Base)>();
        foreach (var map in columnMapping.Mapping)
        {
            var taskColumn = tasks.GetColumnById(map.BoardColumnId);
            if (taskColumn == null) throw new ApplicationException($"Column {taskColumn} not found");

            Board_Column_Base col;
            if (map.DestinationBoardType == typeof(Board_Column_People))
            {
                col = Build_Board_Column_People(taskColumn);
            }
            else if (map.DestinationBoardType == typeof(Board_Column_Timeline))
            {
                col = Build_Board_Column_Timeline(taskColumn);
            }
            else if (map.DestinationBoardType == typeof(Board_Column_Status))
            {
                col = Build_Board_Column_Status(taskColumn);
            }
            else if (map.DestinationBoardType == typeof(Board_Column_String_Value))
            {
                col = Build_Board_Column_String_Value(taskColumn);
            }
            else
            {
                throw new ApplicationException($"Type {map.DestinationBoardType.Name} not supported");
            }

            builded.Add((map.TemplateColumn.ColumnReferenceName, col));
        }

        return builded;
    }

    private Board_Column_String_Value Build_Board_Column_String_Value(MondayDriverBaseColumn column)
    {
        try
        {
            string value = string.Empty;

            if (column.Type == ColumnType.Mirror)
            {
                if (column.ColumnData is MondayDriverMirrorValueColumnData data)
                {
                    value = data.DisplayValue;
                }
            }
            else if (column.Type == ColumnType.Dropdown)
            {
                if (column.ColumnData is MondayDriverDropDownColumnData data)
                {
                    value = data.Text;
                }
            }
            else if (column.Type == ColumnType.Text)
            {
                if (column.ColumnData is MondayDriverTextColumnData data)
                {
                    value = data.Text;
                }
            }
            else if (column.Type == ColumnType.Date)
            {
                if (column.ColumnData is MondayDriverDateColumnData data)
                {
                    value = data.Date.ToString();
                }
            }
            else if (column.Type == ColumnType.Formula)
            {
                if (column.ColumnData is MondayDriverFormulaColumnData data)
                {
                    value = data.Text.ToString();
                }
            }
            else if (column.Type == ColumnType.Status)
            {
                if (column.ColumnData is MondayDriverStatusValueColumnData data)
                {
                    value = StringHelper.ToStringOrStringEmpty(data.Text);
                }
            }
            else if (column.Type == ColumnType.Link)
            {
                if (column.ColumnData is MondayDriverLinkColumnData data)
                {
                    value = StringHelper.ToStringOrStringEmpty(data.Text);
                }
            }
            else
            {
                throw new ApplicationException($"The type of the data column is not compatible with Board_Column_People {column.ColumnData.GetType()}");
            }

            if (String.IsNullOrEmpty(value))
            {
                return Board_Column_String_Value.Create_Unfilled();
            }
            else
            {
                return Board_Column_String_Value.Create(value);
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

    /// <summary>
    /// Method for bulding a Board_Column_People from column with MondayPeopleColumnData
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ApplicationException"></exception>
    public Board_Column_People Build_Board_Column_People(MondayDriverBaseColumn column)
    {
        try
        {
            if (column == null || column.ColumnData == null)
            {
                throw new NullReferenceException("column == null || column.ColumnData == null");
            }

            var people = new List<Board_People>();
            if (column.Type == ColumnType.People)
            {
                if (column.ColumnData is MondayDriverPeopleColumnData data)
                {
                    foreach (var p in data.PersonsAndTeams)
                    {
                        var p1 = Build_Board_Column_People_Board_People(p);
                        people.Add(p1);
                    }

                    return Board_Column_People.Create(data.Updated_at, people);
                }
                else
                {
                    return Board_Column_People.Create_Unfilled();
                }
            }
            else
            {
                throw new ApplicationException($"The type of the data column is not compatible with Board_Column_People {column.ColumnData.GetType()}");
            }


        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

    /// <summary>
    /// Method for bulding a Board_Column_Timeline from column with MondayTimeLineColumnData
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ApplicationException"></exception>
    public Board_Column_Timeline Build_Board_Column_Timeline(MondayDriverBaseColumn column)
    {
        try
        {
            if (column == null || column.ColumnData == null)
            {
                throw new NullReferenceException("column == null || column.ColumnData == null");
            }

            if (column.Type == ColumnType.Timeline)
            {
                if (column.ColumnData is MondayDriverTimeLineColumnData data)
                {
                    DateTime from = data.From;
                    DateTime to = data.To;
                    DateTime changet_at = data.Changed_At;
                    string? visualization_type = data.VisualizationType;
                    return Board_Column_Timeline.Create(from, to, changet_at, visualization_type);
                }
                else
                {
                    return Board_Column_Timeline.Create_Unfilled();
                }
            }
            else
            {
                throw new ApplicationException($"The type of the data column is not compatible with Board_Column_Timeline {column.ColumnData.GetType()}");
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }

    /// <summary>
    /// Method for bulding a Board_Column_Timeline from column with MondayTimeLineColumnData
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ApplicationException"></exception>
    public Board_Column_Status Build_Board_Column_Status(MondayDriverBaseColumn column)
    {
        try
        {
            if (column == null || column.ColumnData == null)
            {
                throw new NullReferenceException("column == null || column.ColumnData == null");
            }

            if (column.Type == ColumnType.Status)
            {
                if (column.ColumnData is MondayDriverStatusValueColumnData data)
                {
                    var index = data.Index.HasValue ? data.Index.Value : -1;
                    var isDone = data.IsDone.HasValue ? data.IsDone.Value : false;
                    var updatedAt = data.UpdatedAt.HasValue ? data.UpdatedAt.Value : DateTime.MinValue;
                    var updateId = data.UpdatedId != null ? data.UpdatedId : "0";
                    return Board_Column_Status.Create(index, isDone, updatedAt, updateId);
                }
                else
                {
                    return Board_Column_Status.Create_Unfilled();
                }
            }
            else
            {
                throw new ApplicationException($"The type of the data column is not compatible with Board_Column_Status {column.ColumnData.GetType()}");
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }

        throw new NotImplementedException();
    }


    /// <summary>
    /// Method for bulding a Board_People from MondayPeopleEntity
    /// </summary>
    /// <param name="peopleEntity"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public Board_People Build_Board_Column_People_Board_People(MondayDriverPeopleEntity peopleEntity)
    {
        try
        {
            if (peopleEntity == null)
            {
                throw new NullReferenceException("peopleEntity == null");
            }

            // Made enum convertion
            var kind = EnumHelper.ConvertEnum<MondayDriverPeopleKindEnum, BoardPeopleKindEnum>(peopleEntity.Kind);

            var people = Board_People.Create(peopleEntity.Id, kind);

            return people;
        }
        catch (Exception ex)
        {
            LoggerHelper.LogException(ex);
            throw;
        }
    }
}



