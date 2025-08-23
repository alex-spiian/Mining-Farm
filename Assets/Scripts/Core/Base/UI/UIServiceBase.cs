using Core.Logger;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class UIServiceBase : MonoBehaviour
    {
        protected SignalBus SignalBus;
        protected DiContainer DiContainer;
        protected ICustomLogger Logger;
        protected UIInputHandler UIInputHandler;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus, ICustomLogger logger, UIInputHandler uiInputHandler)
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
            Logger = logger;
            UIInputHandler = uiInputHandler;
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

        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }
        
        protected abstract string GetTag();
    }
}