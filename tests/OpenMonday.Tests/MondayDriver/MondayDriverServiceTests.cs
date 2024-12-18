using Moq;
using OpenMonday.Core.MondayDriver.Services;
using OpenMonday.Core.strawberryShake;
using OpenMonday.Tests.MondayDriver.TestBuildes;
using StrawberryShake;

namespace OpenMonday.Tests.MondayDriver
{


    public class MondayDriverServiceTests
    {
        private readonly Mock<IMondayClient> _mondayClientMock;
        private readonly Mock<MondayDriverService> _mondayDriverService;
        private readonly Mock<MondayDriverBoardStructureConverterService> _mondayBoardStructureConverterService;
        private readonly Mock<MondayDriverBoardItemsConverterService> _mondayDriverBoardItemsConverterService;

        public MondayDriverServiceTests()
        {
            // Moq IMondayClient
            _mondayClientMock = new Mock<IMondayClient>();

            _mondayBoardStructureConverterService = new Mock<MondayDriverBoardStructureConverterService>();
            _mondayDriverBoardItemsConverterService = new Mock<MondayDriverBoardItemsConverterService>();

            // Moq MondayDriverService
            _mondayDriverService = new Mock<MondayDriverService>(_mondayClientMock.Object, _mondayBoardStructureConverterService.Object, _mondayDriverBoardItemsConverterService.Object)
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
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data.BoardId, boardId);
            Assert.Equal(result.Data.BoardName, boardName);            
            Assert.Equal(result.Data.ItemsCount, 10);
            Assert.Equal(simulatedBoard.Data.Boards.First().Columns.Count, result.Data.BoardColumns.Count);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Id, result.Data.BoardColumns.ElementAt(0).Id);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Title, result.Data.BoardColumns.ElementAt(0).Title);

            // Check groups
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Groups.Count, result.Data.Groups.Count);
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
            Assert.Equal(result.Data.ItemsCount, 10);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.Count, result.Data.BoardColumns.Count);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Id, result.Data.BoardColumns.ElementAt(0).Id);
            Assert.Equal(simulatedBoard.Data.Boards.ElementAt(0).Columns.ElementAt(0).Title, result.Data.BoardColumns.ElementAt(0).Title);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetBoardItemsByCursor_SimpleBoardItemsByCursorResult_Empty()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardItems.GenerateSimpleBoardItemsByCursorResult_Empty();
            string boardId = "xxxxx";

            var mockIGetBoardsByIdQuery = new Mock<IGetBoardItemsByCursorQuery>();
            // Setup del monday client
            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);

            _mondayClientMock
                .Setup(x => x.GetBoardItemsByCursor)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardItemsByCursor(boardId);

            // ASSERT
            Assert.True(result.IsFailure);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetBoardItemsByCursor_SimpleBoardItemsByCursorResult_Fail_Two()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardItems.GenerateSimpleBoardItemsByCursorResult_Two();
            string boardId = "xxxxx";

            var mockIGetBoardsByIdQuery = new Mock<IGetBoardItemsByCursorQuery>();
            // Setup del monday client
            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);

            _mondayClientMock
                .Setup(x => x.GetBoardItemsByCursor)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardItemsByCursor(boardId);

            // ASSERT
            Assert.True(result.IsFailure);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetBoardItemsByCursor_SimpleBoardItemsByCursorResult_Success()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardItems.GenerateSimpleBoardItemsByCursorResult_Success();
            string boardId = "xxxxx";

            var mockIGetBoardsByIdQuery = new Mock<IGetBoardItemsByCursorQuery>();
            // Setup del monday client
            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);

            _mondayClientMock
                .Setup(x => x.GetBoardItemsByCursor)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardItemsByCursor(boardId);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetBoardItemsByCursor_SimpleBoardItemsByCursorResultWithNextPage_Success()
        {
            // ARRANGE
            var simulatedBoard = TestDataBuilders_MondayDriverBoardItems.GenerateSimpleBoardItemsByCursorResult_WithCursor_Success();
            string boardId = "xxxxx";

            // Setup GetBoardItemsByCursor
            var mockIGetBoardsByIdQuery = new Mock<IGetBoardItemsByCursorQuery>();
            mockIGetBoardsByIdQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<IReadOnlyList<string>>(), CancellationToken.None))
                .ReturnsAsync(simulatedBoard);
            _mondayClientMock
                .Setup(x => x.GetBoardItemsByCursor)
                .Returns(mockIGetBoardsByIdQuery.Object);

            // Setup GetBoardItemsByCursor_NextItem
            OperationResult<IGetBoardItemsByCursor_NextPageResult> nextPage = TestDataBuilders_MondayDriverBoardItems.GenerateSimpleBoardItemsByCursor_NextPageResultResult_Success();
            var mockIGetBoardItemsByCursor_NextItemsPageQuery = new Mock<IGetBoardItemsByCursor_NextPageQuery>();
            mockIGetBoardItemsByCursor_NextItemsPageQuery
                .Setup(x => x.ExecuteAsync(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(nextPage);
            _mondayClientMock
                .Setup(x => x.GetBoardItemsByCursor_NextPage)
                .Returns(mockIGetBoardItemsByCursor_NextItemsPageQuery.Object);

            // ACT       
            var result = await _mondayDriverService.Object.GetBoardItemsByCursor(boardId);

            // ASSERT
            Assert.True(result.IsSuccess);
            Assert.Equal(6, result.Data.Count());
            
        }
    }
}