namespace DressZone.Services
{
    using System;
    using DressZone.Services.Contracts;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Drawing.Imaging;
    using Repository.Contracts;
    using Models.Shop;
    

    public class ImagesService : IImagesService
    {
        private IGenericRepository<CategoryImage> categoryImages;
        private string filePathFileSystem = @"D:\TA\FinalProjectMVC\DressZone\DressZone\";
        
        public ImagesService(IGenericRepository<CategoryImage> categoryRepo)
        {
            this.categoryImages = categoryRepo;
        }

        public IQueryable<CategoryImage> GetAllFrontCategoryImages()
        {
            var categoryImages = this.categoryImages.All().Where(c => c.IsDeleted != true && c.IsFrontImage == true);
            return categoryImages;
        }

        public IQueryable<CategoryImage> GetFrontCategoryImage(string categoryName)
        {
            var frontImage = this.categoryImages
                                .All()
                                .Where(i => i.CategoryName == categoryName && i.IsDeleted != true && i.IsFrontImage == true);
            return frontImage;
        }

        public void SaveImageFile(IEnumerable<CategoryImage> models)
        {
            foreach (var item in models)
            {
                if (item != null)
                {
                    var current = ReadFully(item.InputStream);
                    SaveByteArrayToFileSystem(current, item.FileName);
                }
            }
        }

        public void SaveImageRecord(IEnumerable<CategoryImage> currentModels)
        {
            foreach (var model in currentModels)
            {
                if (model != null)
                {
                    //var updatedFilePath = this.filePathFileSystem + model.FileName;
                    model.FileName = model.FileName;
                    categoryImages.Add(model);
                }
              
            }
            categoryImages.SaveChanges();
        }

        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private void SaveByteArrayToFileSystem(byte[] imageBytes,string fileName)
        {
            var path = this.filePathFileSystem + @"DressZone.Server\images\Uploaded\Categories\" + fileName;

            File.WriteAllBytes(path, imageBytes);
        }
    
        private byte[] ImageToByteArraybyMemoryStream(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
