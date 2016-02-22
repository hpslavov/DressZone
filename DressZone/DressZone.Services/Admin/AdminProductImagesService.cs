namespace DressZone.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Shop;
    using DressZone.Services.Contracts;
    using Repository.Contracts;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    public class AdminProductImagesService : IAdminProductImagesService
    {
        private IGenericRepository<ProductImage> productImages;
        private string filePathFileSystem = @"D:\TA\FinalProjectMVC\DressZone\DressZone\";

        public AdminProductImagesService(IGenericRepository<ProductImage> imagesRepo)
        {
            this.productImages = imagesRepo;
        }

        public IQueryable<ProductImage> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductImage> GetFrontImage(string productName)
        {
            throw new NotImplementedException();
        }

        public void SaveImageFile(IEnumerable<ProductImage> models)
        {
            foreach (var item in models)
            {
                if (item != null)
                {
                    var current = ReadFully(item.InputStream);
                    SaveByteArrayToFileSystem(current,item.CategoryName, item.FileName);
                }
            }
        }

        public void SaveImageRecord(IEnumerable<ProductImage> models)
        {
            foreach (var model in models)
            {
                if (model != null)
                {
                    //var updatedFilePath = this.filePathFileSystem + model.FileName;
                    productImages.Add(model);
                }

            }
            productImages.SaveChanges();
        }

        public IEnumerable<ProductImage> GetLatest()
        {
            var delta = DateTime.Now.AddMinutes(-2);
            var imagesLatest = this.productImages.All().Where(i => i.CreatedOn < delta).ToList();
            return imagesLatest;
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

        private void SaveByteArrayToFileSystem(byte[] imageBytes,string directoryName, string fileName)
        {
            var path = this.filePathFileSystem + @"DressZone.Server\images\Uploaded\" + directoryName;
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(path + "\\" + fileName, imageBytes);
        }

        private byte[] ImageToByteArraybyMemoryStream(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
