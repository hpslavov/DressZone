namespace DressZone.Models.Shop
{
    using Common.Contracts;
    using DressZone.Models.Shop.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Web;
    public class CategoryImage
    {
        public int Id { get; set; }
        [Required]
        [Column("Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Column("Original Name")]
        public string FileName { get; set; }

        [Column("Extension")]
        public string ContentType { get; set; }

        public bool IsFrontImage { get; set; }

        [NotMapped]
        public Stream InputStream { get; set; }

        [NotMapped]
        public int ContentLength { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
