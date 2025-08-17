using System;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class LogicServiceBase : IDisposable
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
        
        public virtual void Dispose()
        {
        }
    }
}