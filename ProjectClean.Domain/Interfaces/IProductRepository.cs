using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectClean.Domain.Entities;

namespace ProjectClean.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int? id);

        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}