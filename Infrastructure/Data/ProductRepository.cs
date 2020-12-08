using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var results = await _context.ProductBrands.ToListAsync();
            return results;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _context.products
            .Include(x => x.ProductBrand)
            .Include(x => x.ProductType)
            .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var results = await _context.products
            .Include(x => x.ProductBrand)
            .Include(x => x.ProductType)
            .ToListAsync();
            return results;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var results = await _context.ProductTypes.ToListAsync();
            return results;
        }
    }
}