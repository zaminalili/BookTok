using AutoMapper;
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
    }
}
