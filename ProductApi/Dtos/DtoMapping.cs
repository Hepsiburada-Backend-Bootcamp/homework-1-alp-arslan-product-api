using AutoMapper;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Dtos
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
