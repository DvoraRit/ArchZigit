using Microsoft.Extensions.DependencyInjection;
using ZigitHub.Application.AutoMapper;

namespace ZigitHub.Api.Configs
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ZigitHub.Application.AutoMapper.MapperConfig));
            MapperConfig.RegisterMappings();
        }
    }
}
