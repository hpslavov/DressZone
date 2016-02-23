namespace DressZone.Models.Shop.Common.Contracts
{
    using System;

    public interface IAuditableInfo
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
