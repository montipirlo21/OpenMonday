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
        public async Task ConvertToMondayDriverBaseColumn_PeopleValue_SuccessElaboration()
        {
            // ARRANGE            
            var columns =  new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values>();

            // PEOPLE 1
            var driverPeople1 = new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_PeopleValue("project_owner",
            JsonDocument.Parse("{}").RootElement, ColumnType.People, "", "PeopleValue", new DateTime(2024, 12, 3),
             new List<IGetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams>(){
                    new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams_PeopleEntity("13118233", Kind.Team),
                    new GetBoardItemsByCursor_Boards_Items_page_Items_Column_values_Persons_and_teams_PeopleEntity("66320205", Kind.Team)
             }
           );
           columns.Add(driverPeople1);

           
          

            // ACT       
            var result = _mondayDriverBoardItemsConverterService.Object.ConvertToMondayDriverBaseColumn(columns);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(typeof(List<MondayDriverBaseColumn>), result.GetType());

            // PEOPLE 1
            var people1 = result.FirstOrDefault(x => x.Id == driverPeople1.Id);
            Assert.NotNull(people1);

        }


    }
}