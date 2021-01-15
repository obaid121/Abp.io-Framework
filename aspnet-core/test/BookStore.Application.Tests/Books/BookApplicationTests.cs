using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace BookStore.Books
{
    public class BookAppServiceTests : BookStoreApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookAppServiceTests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
            _bookRepository = GetRequiredService<IRepository<Book, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _bookAppService.GetListAsync(new GetBooksInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6d42ba17-ff44-49f7-bb67-ee579a6e3121")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _bookAppService.GetAsync(Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new BookCreateDto
            {
                Name = "daa85fbc8e654886af6caedd2a8e0e5c1af2850a74dd408a9fd6c979f5bc455ead802f60c95e4e26964125f2bee0e10ad55d"
            };

            // Act
            var serviceResult = await _bookAppService.CreateAsync(input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("daa85fbc8e654886af6caedd2a8e0e5c1af2850a74dd408a9fd6c979f5bc455ead802f60c95e4e26964125f2bee0e10ad55d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new BookUpdateDto()
            {
                Name = "0a0141e1329e48adbd91f1d21a567a142517734d1cc3420b9464df6a3e5d84020d6a1171f2654a7a91c29de099ca4d312fce"
            };

            // Act
            var serviceResult = await _bookAppService.UpdateAsync(Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"), input);

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("0a0141e1329e48adbd91f1d21a567a142517734d1cc3420b9464df6a3e5d84020d6a1171f2654a7a91c29de099ca4d312fce");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _bookAppService.DeleteAsync(Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"));

            // Assert
            var result = await _bookRepository.FindAsync(c => c.Id == Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"));

            result.ShouldBeNull();
        }
    }
}