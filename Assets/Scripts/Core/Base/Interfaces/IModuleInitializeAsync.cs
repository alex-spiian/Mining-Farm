using System.Threading.Tasks;

namespace MiningFarm.Core.Base.Interfaces
{
    public interface IModuleInitializeAsync
    {
        public Task InitializeAsync();
    }
}