using Cysharp.Threading.Tasks;

namespace MiningFarm.Core.Base
{
    public interface IModuleInitializeAsync
    {
        public UniTask InitializeAsync();

        public bool IsInitialized();
        public UniTask CloseAsync();
        public void Dispose();
    }
}