namespace DressZone.Server.Models.DTO.Home
{
    using System.Collections.Generic;

    public class HomePageDTO
    {
        public IEnumerable<HomeCategoryDTO> categories { get; set; }
        public ICollection<HomeProductDTO> products { get; set; }
    }
}
