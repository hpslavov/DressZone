namespace DressZone.Server.Areas.Admin.Models.ViewModels
{
    public class EditCategoryImageRequestModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string OriginalImageName { get; set; }
        public int Quantity { get; set; }
    }
}