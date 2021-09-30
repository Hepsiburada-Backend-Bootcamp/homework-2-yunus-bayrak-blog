using HepsiBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Application.Command.Blog
{
    public class GetAllBlogPostsQuery:IRequest<List<BlogPost>>
    {
    }
}
