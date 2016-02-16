namespace DressZone.Models.Shop.Common
{
    using System;
    using DressZone.Models.Shop.Common.Contracts;

    public class BaseModel 
    {
        public BaseModel()
        {
            this.CreatedOn = DateTime.Now;
        }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
       
    }
}
