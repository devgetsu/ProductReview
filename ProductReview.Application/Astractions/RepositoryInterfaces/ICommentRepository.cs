using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Astractions.RepositoryInterfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}
