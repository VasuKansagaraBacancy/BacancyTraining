using DOTNET_Day3.DOTNET_Day3;

namespace DOTNET_Day3
{
    public class GuidService : IGetGuidSingleton, IGetGuidScoped, IGetGuidTransient
    {
        private readonly Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
