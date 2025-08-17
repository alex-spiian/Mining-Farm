using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class UIServiceBase : MonoBehaviour
    {
        protected SignalBus SignalBus;
        protected DiContainer DiContainer;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus)
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
        }
        
        public virtual async UniTask InitializeAsync()
        {
        }
        
        public virtual async UniTask CloseAsync()
        {
        }
    }
}