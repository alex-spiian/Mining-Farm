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
        protected UIInputHandler UIInputHandler;
        protected ICustomLogger Logger { get; set; }
        protected virtual string Tag => GetType().Name;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            SignalBus signalBus,
            UIInputHandler uiInputHandler,
            ICustomLogger logger
            )
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
            UIInputHandler = uiInputHandler;
            Logger = logger;
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
    }
}