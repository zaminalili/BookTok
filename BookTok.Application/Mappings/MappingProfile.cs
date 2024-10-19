using AutoMapper;
using BookTok.Application.Authors.Commands.CreateAuthor;
using BookTok.Application.Authors.Dtos;
using BookTok.Application.BookAuthors.Command;
using BookTok.Application.Books.Commands.CreateBook;
using BookTok.Application.Books.Commands.UpdateBook;
using BookTok.Application.Books.Dtos;
using BookTok.Application.Categories.Commands.CreateCategory;
using BookTok.Application.Categories.Commands.UpdateCategory;
using BookTok.Application.Categories.Dtos;
using BookTok.Domain.Entities;

namespace BookTok.Application.Mappings;

internal class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();

        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<CreateAuthorCommand, Author>().ReverseMap();

        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<CreateBookCommand, Book>().ReverseMap();
        CreateMap<UpdateBookCommand, Book>().ReverseMap();

        CreateMap<AddBookAuthorCommand, BookAuthor>().ReverseMap();
    }
}
