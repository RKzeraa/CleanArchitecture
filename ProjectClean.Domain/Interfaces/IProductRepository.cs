using System.Collections;
using System.Collections.Generic;
using ProjectClean.Domain.Entities;

namespace ProjectClean.Domain.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Product> GetProducts();
    }
}