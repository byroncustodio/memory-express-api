using AutoMapper;
using System.Linq;
using MemoryExpress.Core.Entities;
using MemoryExpress.Web.Models;

namespace MemoryExpress.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductModel>()
                .ReverseMap();
        }
    }
}