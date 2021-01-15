using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Books;
using BookStore.EntityFrameworkCore;
using Xunit;

namespace BookStore.Books
{
    public class BookRepositoryTests : BookStoreEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetListAsync(
                    name: "7586631f52c64222a429cfbfefabd2a3c48e2d344e3048ac960f33c55590c69970e04d4d44744b33a72f5604d66e99996f28"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _bookRepository.GetCountAsync(
                    name: "49e3df3a35a8444092566e51b66ac31a720408413397436f8d2b91103a2843554d58b70bbc624e8c90284137fdeecfef8d46"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}