
public interface IBoardItemBuilder
{
    Dictionary<string, Board_Column_Base> GenericItemBuilders(TemplateToBoardColumnMappings columnMapping, MondayDriverBaseTask task);

    Board_Column_People Build_Board_Column_People(MondayDriverBaseColumn column);

    Board_People Build_Board_Column_People_Board_People(MondayDriverPeopleEntity peopleEntity);

    Board_Column_Timeline Build_Board_Column_Timeline(MondayDriverBaseColumn column);

    Board_Column_Status Build_Board_Column_Status(MondayDriverBaseColumn column);
}
