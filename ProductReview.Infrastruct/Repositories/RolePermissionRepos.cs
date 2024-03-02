using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.Entities.Models;
using ProductReview.Infrastruct.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Infrastruct.Repositories
{
    public class RolePermissionRepos : BaseRepository<RolePermission>, IRolePermissionRepos
    {
        public RolePermissionRepos(AppDbContext db)
            : base(db) 
        {
        }
    }
}
