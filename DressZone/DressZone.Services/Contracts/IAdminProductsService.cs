namespace DressZone.Services.Contracts
{
    using DTO;
    using Models.Shop;
    using System.Collections.Generic;
    using System.Linq;

    public interface IAdminProductsService
    {
        IQueryable<Product> GetAll();
        IQueryable<Product> GetAllWithDeleted();
        Product GetByName(string productName);
        ProductInfoDTO CreateProduct(Product productToAdd, int colorId, int categoryId, int sizeId, int genderId);
        Product EditProduct(Product productToUpdate);
        Product Delete(Product productToDelete);
        List<DropDownDTO> GetCategoryNames();
        List<DropDownDTO> GetColorNames();
        List<DropDownDTO> GetSizesNames();
        List<DropDownDTO> GetGenderNames();
        Product GetById(int id);
        void SaveImagesToProduct(IEnumerable<ProductImage> images, Product product);
    }
}
