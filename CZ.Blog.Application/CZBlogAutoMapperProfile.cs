using AutoMapper;
using CZ.Blog.Application.Contracts;
using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.Application
{
    public class CZBlogAutoMapperProfile : Profile
    {
        public CZBlogAutoMapperProfile()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();
        }
    }
}
