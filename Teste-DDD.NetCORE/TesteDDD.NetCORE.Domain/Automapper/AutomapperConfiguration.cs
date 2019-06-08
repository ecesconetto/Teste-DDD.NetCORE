using AutoMapper;

namespace TesteDDD.NetCORE.Domain.Automapper
{
    public class AutomapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile(new DomainToViewModelMappingProfile());
                x.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
