using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiBlog.Domain.Entities;
using Mapster;

namespace HepsiBlog.Application.Command.Blog
{
    public class CreateBlogPostCommand : IRequest<BlogPost>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
