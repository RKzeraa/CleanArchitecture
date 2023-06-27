using System.Collections.Generic;
using System.Linq;
using ProjectClean.Domain.Entities;
using ProjectClean.Domain.Interfaces;
using ProjectClean.Infra.Data.Context;

namespace ProjectClean.Infra.Data.Repositories
{
    public class ProductRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}