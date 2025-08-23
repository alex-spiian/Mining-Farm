using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class LogicServiceBase : IDisposable
    {
        protected SignalBus SignalBus;
        protected DiContainer DiContainer;
        protected ICustomLogger Logger;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus, ICustomLogger logger)
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
            Logger = logger;
        }

        public virtual UniTask InitializeAsync()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask CloseAsync()
        {
            return UniTask.CompletedTask;
        }
        
        public virtual void Dispose() { }
        protected abstract string GetTag();
    }
}