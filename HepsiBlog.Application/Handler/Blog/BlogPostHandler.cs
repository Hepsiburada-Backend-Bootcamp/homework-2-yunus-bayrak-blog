using HepsiBlog.Application.Command.Blog;
using HepsiBlog.Domain.Entities;
using HepsiBlog.Domain.UnitOfWork;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiBlog.Application.Handler.Blog
{
    public class BlogPostHandler : IRequestHandler<CreateBlogPostCommand, BlogPost>,
        IRequestHandler<GetAllBlogPostsQuery, List<BlogPost>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BlogPost> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPostEntity = request.Adapt<BlogPost>();
            if (blogPostEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            //Save entities to db
            await _unitOfWork.BlogPostRepository.Add(blogPostEntity);

            return blogPostEntity;
        }

        public async Task<List<BlogPost>> Handle(GetAllBlogPostsQuery request, CancellationToken cancellationToken)
        {
            //Save entities to db
            var posts = await _unitOfWork.BlogPostRepository.GetAll();

            return posts;
        }
    }
}
