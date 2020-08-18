using CZ.Blog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CZ.Blog.Domain.Repositories
{
    public interface ITagRepository : IRepository<Tag, int>
    {
    }
}
