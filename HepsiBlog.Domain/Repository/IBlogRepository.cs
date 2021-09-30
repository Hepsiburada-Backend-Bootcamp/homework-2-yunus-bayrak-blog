using HepsiBlog.Domain.Entities;
using HepsiBlog.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Domain.Repository
{
    public interface IBlogPostRepository : IGenericRepository<BlogPost>
    {
        Task<bool> PublishBlog(BlogPost blog);
    }
}
