using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Domain.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Comment_text { get; set; }
        public int Product_ID { get; set; }

        [ForeignKey(nameof(Product_ID))]
        public Product Product { get; set; }
    }
}
