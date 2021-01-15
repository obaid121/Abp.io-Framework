using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using BookStore.Books;

namespace BookStore.Books
{
    public class BooksDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IBookRepository _bookRepository;

        public BooksDataSeedContributor(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("682c0b6a-1d72-4094-b180-cea1dab40ed5"),
                name: "7586631f52c64222a429cfbfefabd2a3c48e2d344e3048ac960f33c55590c69970e04d4d44744b33a72f5604d66e99996f28"
            ));

            await _bookRepository.InsertAsync(new Book
            (
                id: Guid.Parse("6d42ba17-ff44-49f7-bb67-ee579a6e3121"),
                name: "49e3df3a35a8444092566e51b66ac31a720408413397436f8d2b91103a2843554d58b70bbc624e8c90284137fdeecfef8d46"
            ));
        }
    }
}