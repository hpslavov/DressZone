namespace DressZone.Services.Contracts
{
    using Models.Shop;
    using System.Collections.Generic;
    using System.Linq;
    public interface IImagesService
    {
        void SaveImageRecord(IEnumerable<CategoryImage> models);
        void SaveImageFile(IEnumerable<CategoryImage> models);
        IQueryable<CategoryImage> GetAllFrontCategoryImages();
        IQueryable<CategoryImage> GetFrontCategoryImage(string categoryName);
    }
}
