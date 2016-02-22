namespace DressZone.Services.Contracts
{
    using Models.Shop;
    using System.Collections.Generic;
    using System.Linq;

    public interface IAdminProductImagesService
    {
        void SaveImageRecord(IEnumerable<ProductImage> models);
        void SaveImageFile(IEnumerable<ProductImage> models);
        IQueryable<ProductImage> GetAllImages();
        IQueryable<ProductImage> GetFrontImage(string productName);
        IEnumerable<ProductImage> GetLatest();
    }
}