namespace DressZone.Server.Infrastructure.Mapping.Contracts
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}
