using Moq;
using OpenMonday.Core.MondayDriver.Services;
using OpenMonday.Core.strawberryShake;
using OpenMonday.Tests.MondayDriver.TestBuildes;

namespace OpenMonday.Tests.MondayDriver
{


    public class MondayDriverServiceTests
    {
        private readonly Mock<IMondayClient> _mondayClientMock;
        private readonly Mock<MondayDriverService> _mondayDriverService;
        private readonly Mock<MondayBoardStructureConverterService> _mondayBoardStructureConverterService;

        public MondayDriverServiceTests()
        {
            // Moq IMondayClient
            _mondayClientMock = new Mock<IMondayClient>();

            _mondayBoardStructureConverterService = new Mock<MondayBoardStructureConverterService>();

            // Moq MondayDriverService
            _mondayDriverService = new Mock<MondayDriverService>(_mondayClientMock.Object, _mondayBoardStructureConverterService.Object)
            {
                // Base call where it is not mocked
                CallBase = true
            };
        }

        [Fact]
        public async Task GetBoardsStructureById_SimpleBoardResult_SuccessElaboration()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardStructure.GenerateSimpleBoardResult();
            string boardId = simulatedBoard.Data.Boards.ElementAt(0).Id;
            string boardName = simulatedBoard.Data.Boards.ElementAt(0).Name;

            var mockIGetBoardsByIdQuery = new Mock<IGetBoardsStructureByIdQuery>();

            // Setup del monday client

            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);

            _mondayClientMock
                .Setup(x => x.GetBoardsStructureById)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardsStructureById(boardId);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data.BoardId, boardId);
            Assert.Equal(result.Data.BoardName, boardName);
            Assert.Equal(simulatedBoard.Data.Boards.First().Columns.Count, result.Data.BoardColumns.Count);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Id, result.Data.BoardColumns.ElementAt(0).Id);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Title, result.Data.BoardColumns.ElementAt(0).Title);
            Assert.NotNull(result);

        }

        [Fact]
        public async Task GetBoardsStructureById_SimpleBoardResult_ErrorElaboration()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardStructure.GenerateSimpleBoardResult();
            string boardId = simulatedBoard.Data.Boards.ElementAt(0).Id;
            string boardName = "WrongName";

            var mockIGetBoardsByIdQuery = new Mock<IGetBoardsStructureByIdQuery>();
            // Setup del monday client
            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);

            _mondayClientMock
                .Setup(x => x.GetBoardsStructureById)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardsStructureById(boardId);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.Equal(result.Data.BoardId, boardId);
            Assert.NotEqual(result.Data.BoardName, boardName);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.Count, result.Data.BoardColumns.Count);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Id, result.Data.BoardColumns.ElementAt(0).Id);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Title, result.Data.BoardColumns.ElementAt(0).Title);
            Assert.NotNull(result);
        }
    }
}