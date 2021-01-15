using System;
using BookStore.Books;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Books
{
    public class BookCreateDto
    {
        public Guid AuthorId { get; set; }

        [StringLength(BookConsts.NameMaxLength, MinimumLength = BookConsts.NameMinLength)]
        public string Name { get; set; }
        [Required]
        public BookType Type { get; set; } = BookType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}