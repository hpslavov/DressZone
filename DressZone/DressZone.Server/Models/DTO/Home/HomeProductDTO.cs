
namespace DressZone.Server.Models.DTO.Home
{
    using System;
    using AutoMapper;
    using DressZone.Models.Shop;
    using DressZone.Server.Infrastructure.Mapping.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeProductDTO: IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string FileName { get; set; }
        public int Discount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            Mapper.CreateMap<Product, HomeProductDTO>()
                .ForMember(x => x.FileName, opts => opts.MapFrom(src => src.Images.FirstOrDefault().FileName));
        }
    }
}