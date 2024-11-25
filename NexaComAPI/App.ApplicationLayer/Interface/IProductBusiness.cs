using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IProductBusiness
    {

        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(ProductModel productDto);
        Task<bool> UpdateProductAsync(ProductModel productDto);
        Task<bool> DeleteProductAsync(int id);

    }
}
