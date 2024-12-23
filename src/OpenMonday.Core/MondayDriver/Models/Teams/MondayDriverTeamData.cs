
public class MondayDriverTeamData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<MondayDriverUserData> Owners { get; set; }
    public List<MondayDriverUserData> Users { get; set; }

    public MondayDriverTeamData(string id, string name, List<MondayDriverUserData> owners, List<MondayDriverUserData> users)
    {
        Id = id;
        Name = name;
        Owners = owners;
        Users = users;
    }

    public static MondayDriverTeamData Create(string id, string name, List<MondayDriverUserData> owners, List<MondayDriverUserData> users)
    {
        return new MondayDriverTeamData(id, name, owners, users);
    }
}
