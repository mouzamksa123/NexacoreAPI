using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
   public class ProductModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int MinimumOrderQuantity { get; set; }

        public decimal Discount { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

    }
}
