using System;
using BookStore.Authors;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<AuthorDto> GetAsync(Guid id);

        Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input);

        Task<AuthorDto> CreateAsync(AuthorCreateDto input);

        Task UpdateAsync(Guid id, AuthorUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}