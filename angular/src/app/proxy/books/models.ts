import type { EntityDto, FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { BookType } from './book-type.enum';

export interface AuthorLookupDto extends EntityDto<string> {
  name?: string;
}

export interface BookCreateDto {
  authorId?: string;
  name?: string;
  type: BookType;
  publishDate: string;
  price: number;
}

export interface BookDto extends FullAuditedEntityDto<string> {
  authorId?: string;
  authorName?: string;
  name?: string;
  type: BookType;
  publishDate?: string;
  price: number;
}

export interface BookUpdateDto {
  authorId?: string;
  name?: string;
  type: BookType;
  publishDate: string;
  price: number;
}

export interface GetBooksInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
}
