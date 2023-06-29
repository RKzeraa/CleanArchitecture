using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectClean.Application.Mappings;

namespace ProjectClean.MVC.MappingConfig
{
    public static class AddAutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
           if (services == null) throw new ArgumentNullException(nameof(services));

           services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
        }
    }
}