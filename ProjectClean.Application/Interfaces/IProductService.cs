using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectClean.Application.ViewModels;

namespace ProjectClean.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetById(int? id);

        void Add(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(int? id);
    }
}