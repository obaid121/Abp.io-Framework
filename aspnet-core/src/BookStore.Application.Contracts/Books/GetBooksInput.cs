using Volo.Abp.Application.Dtos;
using System;

namespace BookStore.Books
{
    public class GetBooksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Name { get; set; }

        public GetBooksInput()
        {

        }
    }
}