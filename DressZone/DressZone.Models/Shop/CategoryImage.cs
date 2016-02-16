namespace DressZone.Models.Shop
{
    using DressZone.Models.Shop.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Web;
    public class CategoryImage : BaseModel
    {
        public CategoryImage() : base()
        {
        }

        [Required]
        [Column("Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Column("Original Name")]
        public string FileName { get; set; }

        [Column("Extension")]
        public string ContentType { get; set; }

        public bool IsFrontImage { get; set; }

        public string OriginalFileName { get; set; }

        [NotMapped]
        public Stream InputStream { get; set; }

        [NotMapped]
        public int ContentLength { get; set; }

    }
}
