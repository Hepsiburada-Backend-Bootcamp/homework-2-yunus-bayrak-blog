using HepsiBlog.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBlog.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBlogPostRepository BlogPostRepository { get; }
    }
}
