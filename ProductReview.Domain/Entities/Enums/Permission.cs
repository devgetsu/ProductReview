using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Domain.Entities.Enums
{
    public enum Permission
    {
        CreateUser = 1,
        DeleteUser,
        UpdateUser,
        GetUser,
        CreateProduct,
        UpdateProduct,
        DeleteProduct,
        GetProduct
    }
}
