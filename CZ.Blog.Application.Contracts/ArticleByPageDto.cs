using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CZ.Blog.Application.Contracts
{
    public class ArticleByPageDto
    {
        public long Total { get; set; }
        public List<ArticleDto> ArticleDtos { get; set; }
    }
}
