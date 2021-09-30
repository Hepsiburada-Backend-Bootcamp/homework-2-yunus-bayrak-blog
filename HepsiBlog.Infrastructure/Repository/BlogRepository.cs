using HepsiBlog.Domain.Entities;
using HepsiBlog.Domain.Repository;
using HepsiBlog.Domain.Repository.Base;
using HepsiBlog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Infrastructure.Repository
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BlogDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<bool> PublishBlog(BlogPost blog)
        {
            var currentBlog = _dbSet.Find(blog.Id);
            currentBlog.Title = "Published" + blog.Title;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
