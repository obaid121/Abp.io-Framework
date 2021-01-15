using System;
using BookStore.Shared;
using BookStore.Books;
using BookStore.Authors;
using AutoMapper;
using BookStore.Users;
using Volo.Abp.AutoMapper;

namespace BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserDto>().Ignore(x => x.ExtraProperties);

            CreateMap<BookCreateDto, Book>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<BookUpdateDto, Book>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Book, BookDto>();

            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();
        }
    }
}