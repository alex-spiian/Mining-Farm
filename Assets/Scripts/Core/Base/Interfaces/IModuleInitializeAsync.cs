using Cysharp.Threading.Tasks;

namespace MiningFarm.Core.Base.Interfaces
{
    public interface IModuleInitializeAsync
    {
        public UniTask InitializeAsync();
    }
}