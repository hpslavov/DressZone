namespace DressZone.Server.Models.DTO.Home
{
    using System.Collections.Generic;

    public class HomePageDTO
    {
        public IEnumerable<HomeCategoryDTO> categories { get; set; }
        public IEnumerable<HomeProductDTO> products { get; set; }
    }
}
