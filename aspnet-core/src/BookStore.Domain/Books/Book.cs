using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using BookStore.Books;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace BookStore.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
        public Guid AuthorId { get; set; }

        public Book()
        {

        }

        public Book(Guid id, string name)
        {
            Id = id;
            Check.Length(name, nameof(name), BookConsts.NameMaxLength, BookConsts.NameMinLength);
            Name = name;
        }
    }
}