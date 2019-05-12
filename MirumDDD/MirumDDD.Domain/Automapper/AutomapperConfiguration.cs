using AutoMapper;

namespace MirumDDD.Domain.Automapper
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
