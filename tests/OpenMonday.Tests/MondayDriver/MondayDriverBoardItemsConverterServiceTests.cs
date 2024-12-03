using System.Text.Json;
using Moq;
using OpenMonday.Core.strawberryShake;

namespace OpenMonday.Tests.MondayDriver
{
    public class MondayDriverBoardItemsConverterServiceTests
    {
        private readonly Mock<MondayDriverBoardItemsConverterService> _mondayDriverBoardItemsConverterService;

        public MondayDriverBoardItemsConverterServiceTests()
        {
            // Moq MondayDriverService
            _mondayDriverBoardItemsConverterService = new Mock<MondayDriverBoardItemsConverterService>()
            {
                // Base call where it is not mocked
                CallBase = true
            };
        }

        [Fact]
        public void ConvertToMondayDriverBaseColumn_PeopleValue_SuccessElaboration()
        {
            // ARRANGE            
            var columns = new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>();

            // PEOPLE 1
            var driverPeople1 = new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
            JsonDocument.Parse("{}").RootElement, ColumnType.People, "Name Surname, AnotherUser@aaaaaa.com", "PeopleValue", new DateTime(2024, 12, 3),
             new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams>(){
                    new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams_PeopleEntity("55860256", Kind.Person),
                    new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams_PeopleEntity("66320205", Kind.Team)
             }
           );

            // PEOPLE 2
            var driverPeople2 = new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner_2",
            JsonDocument.Parse("{}").RootElement, ColumnType.People, string.Empty, "PeopleValue", null,
             new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams>()
             {
             }
           );
            columns.Add(driverPeople1);

            // ACT       
            var result = _mondayDriverBoardItemsConverterService.Object.ConvertToMondayDriverBaseColumn(columns);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(typeof(List<MondayDriverBaseColumn>), result.GetType());

            // ASSERT PEOPLE 1
            var people1 = result.FirstOrDefault(x => x.Id == driverPeople1.Id);
            var people1Data = (MondayDriverPeopleColumnData)people1.ColumnData;
            Assert.NotNull(people1);
            Assert.NotNull(people1Data);
            Assert.Equal(typeof(MondayDriverPeopleColumnData), people1Data.GetType());
            Assert.Equal(people1Data.Updated_at, driverPeople1.Updated_at);
            foreach (var person in driverPeople1.Persons_and_teams)
            {
                var p = people1Data.PersonsAndTeams.FirstOrDefault(x => x.Id.Equals(person.Id));
                Assert.NotNull(p);
                Assert.Equal(p.Id, person.Id);
                Assert.Equal(p.Kind.ToString(), person.Kind.ToString());
            }

            // ASSERT PEOPLE 2
            var people2 = result.FirstOrDefault(x => x.Id == driverPeople1.Id);
            var people2Data = (MondayDriverPeopleColumnData)people2.ColumnData;
            Assert.Equal(people1Data.Updated_at, driverPeople1.Updated_at);
        }
    }
}