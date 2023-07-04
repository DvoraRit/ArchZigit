using AutoMapper;

namespace ZigitHub.Application.AutoMapper
{
    public static class MapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new DomainToViewModelMappingProfile());
                //cfg.AddProfile(new ViewModelToDomainMappingProfile());
                
            });
        }
    }
}
