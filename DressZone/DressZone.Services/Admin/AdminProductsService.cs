namespace DressZone.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Shop;
    using DressZone.Services.Contracts;
    using Repository.Contracts;
    using DTO;
    public class AdminProductsService : IAdminProductsService
    {
        private IGenericRepository<Product> productsRepo;
        private IGenericRepository<Category> categoriesRepo;
        private IGenericRepository<Size> sizesRepo;
        private IGenericRepository<Color> colorsRepo;
        private IGenericRepository<GenderType> gendersRepo;



        public AdminProductsService(IGenericRepository<Product> products,
                                    IGenericRepository<Category> categories,
                                    IGenericRepository<Size> sizes,
                                    IGenericRepository<Color> colors,
                                    IGenericRepository<GenderType> genders)
        {
            this.productsRepo = products;
            this.categoriesRepo = categories;
            this.sizesRepo = sizes;
            this.colorsRepo = colors;
            this.gendersRepo = genders;
        }

        public ProductInfoDTO CreateProduct(Product productToAdd, int colorId, int categoryId, int sizeId, int genderId)
        {
            var color = this.colorsRepo.GetById(colorId);
            var category = this.categoriesRepo.GetById(categoryId);
            var size = this.sizesRepo.GetById(sizeId);
            var gender = this.gendersRepo.GetById(genderId);
            productToAdd.Category = category;
            productToAdd.Colors.Add(color);
            productToAdd.Gender = gender;
            productToAdd.Sizes.Add(size);
            this.productsRepo.Add(productToAdd);
            this.productsRepo.SaveChanges();
            var result = this.GetByName(productToAdd.Title);
            var dtoModel = new ProductInfoDTO { ProductId = result.Id, Title = result.Title, CategoryName = result.Category.Name };
            return dtoModel;
        }

        public Product Delete(Product productToDelete)
        {
            productToDelete.IsDeleted = true;
            this.productsRepo.AddDeleteFlag(productToDelete);
            return productToDelete;
        }

        public Product GetById(int id)
        {
            var result = this.productsRepo.GetById(id);
            return result;
        }

        public void SaveImagesToProduct(IEnumerable<ProductImage> images,Product product)
        {
            foreach (var img in images)
            {
                product.Images.Add(img);
            }
            product.ModifiedOn = DateTime.Now;
            this.productsRepo.Update(product);
            this.productsRepo.SaveChanges();
        }

        public Product EditProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            var notDeletedProducts = this.productsRepo.All().Where(p => p.IsDeleted != true);
            return notDeletedProducts;
        }

        public IQueryable<Product> GetAllWithDeleted()
        {
            var allProducts = this.productsRepo.All();
            return allProducts;
        }

        public Product GetByName(string productName)
        {
            var resultProduct = this.productsRepo.All().Where(p => p.Title == productName && p.IsDeleted != true).FirstOrDefault();
            return resultProduct;
        }

        public List<DropDownDTO> GetCategoryNames()
        {
            var names = this.categoriesRepo.All().Select(x => new DropDownDTO { Name = x.Name, Id = x.Id }).ToList();
            return names;
        }

        public List<DropDownDTO> GetColorNames()
        {
            var names = this.colorsRepo.All().Select(c => new DropDownDTO { Id = c.Id, Name = c.Name }).ToList();
            return names;
        }

        public List<DropDownDTO> GetSizesNames()
        {
            var names = this.sizesRepo.All().Select(x => new DropDownDTO { Name = x.Name, Id = x.Id }).ToList();
            return names;
        }

        public List<DropDownDTO> GetGenderNames()
        {
            var names = this.gendersRepo.All().Select(x => new DropDownDTO { Name = x.Name, Id = x.Id }).ToList();
            return names;
        }

    }
}
