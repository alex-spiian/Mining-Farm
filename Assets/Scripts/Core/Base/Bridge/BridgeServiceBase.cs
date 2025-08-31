using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class BridgeServiceBase<TLogicService, TUIService, TModuleConfig> : Loggable,
        IModuleInitializeAsync,
        IDisposable,
        IInitializable
        where TLogicService : LogicServiceBase 
        where TUIService : UIServiceBase
        where TModuleConfig : ModuleConfigBase
    {
        protected DiContainer DiContainer;
        protected SignalBus SignalBus;
        
        protected TLogicService LogicService;
        protected TUIService UIService;
        protected TModuleConfig ModuleConfig;
        
        private bool _isInitialized;

        [Inject]
        public void Construct(DiContainer diContainer, TLogicService logicService, TModuleConfig moduleConfig, SignalBus signalBus)
        {
            DiContainer = diContainer;
            LogicService = logicService;
            ModuleConfig = moduleConfig;
            SignalBus = signalBus;
        }
        
        public void Initialize()
        {
            if (IsAutoInitialize)
                InitializeAsync().Forget();
        }

        protected abstract bool IsAutoInitialize { get; }
        
        public virtual async UniTask InitializeAsync()
        {
            UIService = DiContainer.InstantiatePrefabForComponent<TUIService>(ModuleConfig.UIServicePrefab, parentTransform: null);
            
            await LogicService.InitializeAsync();
            await UIService.InitializeAsync();
            
            Subscribe();
            _isInitialized = true;
        }

        public virtual bool IsInitialized()
        {
            return _isInitialized;
        }

        public virtual async UniTask CloseAsync()
        {
            Unsubscribe();
            await UIService.CloseAsync();
            await LogicService.CloseAsync();
        }

        public virtual void Dispose()
        {
            LogicService.Dispose();
        }
        
        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }
    }
}