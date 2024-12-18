using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.strawberryShake;

public class MondayDriverBoardItemsConverterService : IMondayDriverBoardItemsConverterService
{
    public List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_Boards_Items_page_Items> value)
    {
        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        var tasks = new List<MondayDriverBaseTask>();
        foreach (var item in value)
        {
            var task = ConvertToMondayDriverBaseTask(item);
            tasks.Add(task);
        }

        return tasks;
    }

    public MondayDriverBaseTask ConvertToMondayDriverBaseTask(IGetBoardItemsByCursor_Boards_Items_page_Items value)
    {

        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        // Check the group value
        if (value.Group == null)
        {
            throw new NullReferenceException("value.Group");
        }

        // Build the columns
        List<MondayDriverBaseColumn> baseColumns = ConvertToMondayDriverBaseColumn(value.Column_values);
        return MondayDriverBaseTask.Create(value.Id, value.Name, value.Group.Id, baseColumns);
    }

    public List<MondayDriverBaseColumn> ConvertToMondayDriverBaseColumn(IReadOnlyList<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values> value)
    {
        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        List<MondayDriverBaseColumn> columns = new List<MondayDriverBaseColumn>();
        foreach (var column in value)
        {
            var b = ConvertToMondayDriverBaseColumn(column);
            columns.Add(b);
        }

        return columns;
    }

    public MondayDriverBaseColumn ConvertToMondayDriverBaseColumn(IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values value)
    {

        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        // Have to call the columndataconverter
        MondayDriverBaseColumnData columnData;

        columnData = ConvertToMondayDriverBaseColumnData(value.Type, value);

        return MondayDriverBaseColumn.Create(value.Id, value.Text, value.Type, value.__typename, value.Value.ToString(), columnData);
    }

    public MondayDriverBaseColumnData ConvertToMondayDriverBaseColumnData(ColumnType type, IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values val)
    {
        try
        {
            MondayDriverBaseColumnData result = new MondayDriverBaseColumnData();


            switch (type)
            {
                case ColumnType.People:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue)val;
                        List<MondayDriverPeopleEntity> peopleEntities = [];
                        if (v.Persons_and_teams != null)
                        {
                            foreach (var p in v.Persons_and_teams)
                            {
                                if (p.Kind is not null)
                                {
                                    var c = MondayDriverPeopleEntity.Create(p.Id, EnumHelper.ConvertEnum<Kind, MondayDriverPeopleKindEnum>(p.Kind.Value));
                                    peopleEntities.Add(c);
                                }
                                else
                                {
                                    LoggerHelper.LogError($"Person without kind: {p.Id}");
                                }
                            }
                        }
                        result = MondayDriverPeopleColumnData.Create(v.Updated_at, peopleEntities);
                        break;
                    }
                case ColumnType.Timeline:
                    {
                        if (val.Value == null || val.Value.Value.Equals(string.Empty))
                        {
                            return result;
                        }
                        string sValue = val.Value.Value.ToString();
                        result = JsonHelper.Deserialize<MondayDriverTimeLineColumnData>(sValue);
                        break;
                    }
                case ColumnType.Status:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_StatusValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_StatusValue)val;
                        result = MondayDriverStatusValueColumnData.Create(v.Text, v.Index, v.Is_done, v.Updated_at, v.Update_id);
                        break;
                    }
                case ColumnType.Mirror:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_MirrorValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_MirrorValue)val;
                        result = MondayDriverMirrorValueColumnData.Create(v.Display_value);
                        break;
                    }
                case ColumnType.Dropdown:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_DropdownValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_DropdownValue)val;
                        result = MondayDriverDropDownColumnData.Create(v.Text);
                        break;
                    }
                case ColumnType.Text:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_TextValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_TextValue)val;
                        result = MondayDriverTextColumnData.Create(v.Text);
                        break;
                    }
                case ColumnType.Date:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_DateValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_DateValue)val;
                        if (val.Value == null || val.Value.Value.Equals(string.Empty))
                        {
                            return result;
                        }
                        string sValue = val.Value.Value.ToString();
                        result = JsonHelper.Deserialize<MondayDriverDateColumnData>(sValue);
                        break;
                    }
                case ColumnType.Formula:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_FormulaValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_FormulaValue)val;
                        result = MondayDriverFormulaColumnData.Create(v.Text);
                        break;
                    }
                case ColumnType.Link:
                    {
                        IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_LinkValue v = (IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_LinkValue)val;
                        result = MondayDriverLinkColumnData.Create(v.Text);
                        break;
                    }
                default:
                    break;
            }

            return result;
        }
        catch (Exception e)
        {
            LoggerHelper.LogError($"Errore nella conversione dei valori: {type} && {val.Value}");
            LoggerHelper.LogException(e);
            throw;
        }
    }

    #region NEXT PAGE 

    public List<MondayDriverBaseTask> Convert_GetBoardItemsByCursor_MondayDriverBaseTask(IReadOnlyList<IGetBoardItemsByCursor_NextPage_Next_items_page_Items> value)
    {
        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        var tasks = new List<MondayDriverBaseTask>();
        foreach (var item in value)
        {
            var task = ConvertToMondayDriverBaseTask(item);
            tasks.Add(task);
        }

        return tasks;
    }

    public MondayDriverBaseTask ConvertToMondayDriverBaseTask(IGetBoardItemsByCursor_NextPage_Next_items_page_Items value)
    {

        if (value == null)
        {
            throw new NullReferenceException("value has to be not null");
        }

        // Check the group value
        if (value.Group == null)
        {
            throw new NullReferenceException("value.Group");
        }

        // Build the Columns
        List<MondayDriverBaseColumn> baseColumns = ConvertToMondayDriverBaseColumn(value.Column_values);
        return MondayDriverBaseTask.Create(value.Id, value.Name, value.Group.Id, baseColumns);
    }

    #endregion
}