using Volo.Abp.Application.Dtos;

namespace BookStore.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}