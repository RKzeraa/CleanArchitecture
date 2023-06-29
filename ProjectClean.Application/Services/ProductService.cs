using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjectClean.Application.Interfaces;
using ProjectClean.Application.ViewModels;
using ProjectClean.Domain.Entities;
using ProjectClean.Domain.Interfaces;

namespace ProjectClean.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProjectRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductService(IProjectRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductViewModel>> GetProducts() => _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProducts());
        
        public async Task<ProductViewModel> GetById(int? id) => _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        
        public void Add(ProductViewModel productViewModel) => _productRepository.Add(_mapper.Map<Product>(productViewModel));
        
        public void Update(ProductViewModel productViewModel) => _productRepository.Update(_mapper.Map<Product>(productViewModel));
        
        public void Remove(int? id) => _productRepository.Remove(_productRepository.GetById(id).Result);
    }
}