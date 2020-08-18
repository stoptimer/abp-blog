using CZ.Blog.Application.IServices;
using CZ.Blog.Domain.Repositories;

namespace CZ.Blog.Application.Services
{
    public partial class BlogService : CZBlogApplicationServiceBase, IBlogService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserRepository _userRepository;

        public BlogService(IArticleRepository articleRepository, ICategoryRepository categoryRepository, ITagRepository tagRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
        }

       
    }
}
