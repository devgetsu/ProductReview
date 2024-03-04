using NewProductReview.Applicaion.Abstraction.RepositoryInterfaces;
using ProductReview.Domain.Entities.Models;
using ProductReview.Infrastruct.Persistance;
using ProductReview.Infrastruct.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProjectReview.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
