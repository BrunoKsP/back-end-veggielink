using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace aplication.AutoMapper;

public class AutoMapperSetup
{
    protected AutoMapperSetup()
    { }

    public static MapperConfiguration RegisterMappings(IConfiguration config)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DomainToDtoMapping(config));
            cfg.AddProfile(new DtoToDomainMapping());
        });
    }
}
