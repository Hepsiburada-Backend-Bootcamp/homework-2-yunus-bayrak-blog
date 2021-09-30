using HepsiBlog.Domain.Repository;
using System;
using Microsoft.Extensions.DependencyInjection;
using HepsiBlog.Domain.UnitOfWork;

namespace HepsiBlog.Infrastructure.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private IServiceProvider _serviceProvider;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IBlogPostRepository BlogPostRepository => _serviceProvider.GetService<IBlogPostRepository>();
    }
}
