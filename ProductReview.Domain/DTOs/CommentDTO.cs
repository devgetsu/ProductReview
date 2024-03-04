using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Domain.DTOs
{
    public class CommentDTO
    {
        public string Comment_text {  get; set; }
        public int Product_id { get; set;}
    }
}
