using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class UIServiceBase : LoggableMonoBehaviour
    {
        protected SignalBus SignalBus;
        protected DiContainer DiContainer;
        protected UIInputHandler UIInputHandler;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus, UIInputHandler uiInputHandler)
        {
            DiContainer = diContainer;
            SignalBus = signalBus;
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
    }
}