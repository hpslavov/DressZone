namespace DressZone.Context.Migrations
{
    using Models.Shop;
    using System;
    using System.Collections.Generic;

    public class SeedData
    {
        public ICollection<Size> Sizes;
        public ICollection<Category> Categories;
        public ICollection<Color> Colors;
        public ICollection<GenderType> GenderTypes;
        public ICollection<Shipping> ShippingTypes;

        public SeedData()
        {
            this.Sizes = new List<Size>();
            this.Categories = new List<Category>();
            this.Colors = new List<Color>();
            this.GenderTypes = new List<GenderType>();
            this.ShippingTypes = new List<Shipping>();
            this.PopulateGenders();
            this.PopulateColors();
            this.PopulateShippingType();
            this.PopulateCategories();
            this.PopulateSizes();
        }

        public void PopulateSizes()
        {
            this.Sizes.Add(
                new Size { Name = "XS" });
            this.Sizes.Add(
            new Size { Name = "S" });
            this.Sizes.Add(
            new Size { Name = "M" });
            this.Sizes.Add(
            new Size { Name = "L" });
            this.Sizes.Add(
            new Size { Name = "XL" });
        }

        public void PopulateGenders()
        {
            this.GenderTypes.Add(
                new GenderType { Name = "Male" });
            this.GenderTypes.Add(
             new GenderType { Name = "Female" });
        }

        public void PopulateColors()
        {
            this.Colors.Add(
                new Color { Name = "White" });
            this.Colors.Add(
                new Color { Name = "Black" });
            this.Colors.Add(
                new Color { Name = "Green" });
            this.Colors.Add(
                new Color { Name = "Yellow" });
            this.Colors.Add(
                new Color { Name = "Brown" });
            this.Colors.Add(
                new Color { Name = "SpaceBlue" });
            this.Colors.Add(
                new Color { Name = "Blue" });
            this.Colors.Add(
                new Color { Name = "Gray" });
            this.Colors.Add(
                new Color { Name = "Navy" });
            this.Colors.Add(
                new Color { Name = "Red" });
        }

        public void PopulateShippingType()
        {
            this.ShippingTypes.Add(
                new Shipping { Name = "Local", Country = "Bulgaria", City = "Sofia", Fee = 5.0m });
            this.ShippingTypes.Add(
                new Shipping { Name = "CountrySide", Country = "Bulgaria", City = "Plovdiv", Fee = 9.0m });
            this.ShippingTypes.Add(
                new Shipping { Name = "Local", Country = "Bulgaria", City = "Varna", Fee = 12.0m });
            this.ShippingTypes.Add(
                new Shipping { Name = "CountrySide", Country = "Bulgaria", City = "Bourgas", Fee = 15.0m });
            this.ShippingTypes.Add(
                new Shipping { Name = "Local", Country = "Bulgaria", City = "Veliko Turnovo", Fee = 8.0m });
            this.ShippingTypes.Add(
                new Shipping { Name = "CountrySide", Country = "Bulgaria", City = "Pleven", Fee = 4.0m });
        }

        public void PopulateCategories()
        {
            this.Categories.Add(
                new Category { Name = "Skirts", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Jeans", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Sweaters", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Bags", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Accessories", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Ties", Quantity = 0 });
            this.Categories.Add(
                new Category { Name = "Jackets", Quantity = 0 });
        }
    }
}
