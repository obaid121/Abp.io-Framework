using System;
using Volo.Abp.Application.Dtos;
using BookStore.Authors;

namespace BookStore.Authors
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}