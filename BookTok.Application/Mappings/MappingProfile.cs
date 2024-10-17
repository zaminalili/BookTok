using AutoMapper;
using BookTok.Application.Categories.Dtos;
using BookTok.Domain.Entities;

namespace BookTok.Application.Mappings;

internal class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
