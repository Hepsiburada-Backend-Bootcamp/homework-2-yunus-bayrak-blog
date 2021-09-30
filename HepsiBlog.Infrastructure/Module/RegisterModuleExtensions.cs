using HepsiBlog.Domain.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using HepsiBlog.Infrastructure.UnitOfWorks;
using HepsiBlog.Domain.Repository;
using HepsiBlog.Infrastructure.Repository;
using HepsiBlog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HepsiBlog.Infrastructure.Module
{
    public static class RegisterModuleExtensions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BlogDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            //"server=X;database=MyBlogDb;integrated security=true;"
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IBlogPostRepository, BlogPostRepository>();
        }
    }
}
