namespace DOTNET_Day3
{
    namespace DOTNET_Day3
    {
        public interface IGetGuidSingleton { Guid GetGuid(); }
        public interface IGetGuidScoped { Guid GetGuid(); }
        public interface IGetGuidTransient { Guid GetGuid(); }
    }

}
