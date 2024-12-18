using Moq;
using OpenMonday.Tests.MondayDriver.TestBuildes;

public class MondayDriverBoardStructureConverterServiceTests
{
    private readonly Mock<MondayDriverBoardStructureConverterService> _mondayDriverBoardStructureConverterService;

    public MondayDriverBoardStructureConverterServiceTests()
    {
        // Moq MondayDriverService
        _mondayDriverBoardStructureConverterService = new Mock<MondayDriverBoardStructureConverterService>()
        {
            // Base call where it is not mocked
            CallBase = true
        };
    }

    [Fact]
    public void ConvertToColumnSettingSchema_Status_Success()
    {
        // ARRANGE            
        var column = TestDataBuilders_MondayDriverBoardStructure.GenerateStatusColumnResult();

        // ACT       
        var result = _mondayDriverBoardStructureConverterService.Object.ConvertToColumnSchema(column);

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(result.Title,column.Title);
        Assert.Equal(result.Type, column.Type.ToString());
        Assert.Equal(typeof(MondayDriverColumnStatusSettingSchema), result.Settings.GetType());

        // SETTINGS 
        Assert.NotNull(result.Settings);
        Assert.NotNull(((MondayDriverColumnStatusSettingSchema)result.Settings).DoneColors);
        Assert.NotNull(((MondayDriverColumnStatusSettingSchema)result.Settings).Labels);
        Assert.NotNull(((MondayDriverColumnStatusSettingSchema)result.Settings).LabelsColors);
        Assert.NotNull(((MondayDriverColumnStatusSettingSchema)result.Settings).LabelsPositionsV2);
    }
}