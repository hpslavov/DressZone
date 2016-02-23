namespace DressZone.Server.Areas.Admin.Models.ViewModels.Products
{
    using DressZone.Models.Shop;
    using Infrastructure.Mapping.Contracts;
    using Services.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System.Web;
    public class GridCreateProductViewModel : IMapTo<Product>, IMapFrom<Product>
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [IgnoreMap]
        [UIHint("Colors")]
        public DropDownDTO Color { get; set; }

        [IgnoreMap]
        [UIHint("Sizes")]
        public DropDownDTO Size { get; set; }

        [IgnoreMap]
        [UIHint("Category")]
        public DropDownDTO Category { get; set; }

        [IgnoreMap]
        [UIHint("Genders")]
        public DropDownDTO Gender { get; set; }

        public int? Discount { get; set; }

        public int? Rating { get; set; }

    }
}