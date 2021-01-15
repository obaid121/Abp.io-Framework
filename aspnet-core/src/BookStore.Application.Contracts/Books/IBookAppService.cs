using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{
    public interface IBookAppService : IApplicationService,
     ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            BookCreateDto,
            BookUpdateDto>//Used to create/update a book
    {
        //Task<PagedResultDto<BookDto>> GetListAsync(GetBooksInput input);

        //Task<BookDto> GetAsync(Guid id);

        //Task DeleteAsync(Guid id);

        //Task<BookDto> CreateAsync(BookCreateDto input);

        //Task<BookDto> UpdateAsync(Guid id, BookUpdateDto input);

        // ADD the NEW METHOD
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}