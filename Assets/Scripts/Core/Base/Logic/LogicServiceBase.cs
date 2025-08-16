using Cysharp.Threading.Tasks;

namespace MiningFarm.Core.Base
{
    public abstract class LogicServiceBase
    {
        public virtual async UniTask InitializeAsync()
        {
        }
    }
}