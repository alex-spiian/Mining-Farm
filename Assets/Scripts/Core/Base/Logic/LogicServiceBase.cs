using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class LogicServiceBase : Loggable, IDisposable
    {
        protected SignalBus SignalBus;
        protected DiContainer DiContainer;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus)
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
        }

        public virtual UniTask InitializeAsync()
        {
            Subscribe();
            return UniTask.CompletedTask;
        }

        public virtual UniTask CloseAsync()
        {
            Unsubscribe();
            return UniTask.CompletedTask;
        }
        
        public virtual void Dispose() { }
        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }
    }
}