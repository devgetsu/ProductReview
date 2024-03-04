using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProductReview.Applicaion.Abstraction.RepositoryInterfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
