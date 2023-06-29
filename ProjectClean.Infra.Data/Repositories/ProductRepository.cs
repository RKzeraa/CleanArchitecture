using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}