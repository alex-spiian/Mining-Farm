using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class BridgeServiceBase<TLogicService, TUIService, TModuleConfig> : IModuleInitializeAsync, IDisposable
        where TLogicService : LogicServiceBase 
        where TUIService : UIServiceBase
        where TModuleConfig : ModuleConfigBase
    {
        protected DiContainer DiContainer;
        protected SignalBus SignalBus;
        protected ICustomLogger Logger;
        
        protected TLogicService LogicService;
        protected TUIService UIService;
        protected TModuleConfig ModuleConfig;
        
        private bool _isInitialized;

        [Inject]
        public void Construct(DiContainer diContainer, TLogicService logicService, TModuleConfig moduleConfig, SignalBus signalBus, ICustomLogger logger)
        {
            DiContainer = diContainer;
            LogicService = logicService;
            ModuleConfig = moduleConfig;
            SignalBus = signalBus;
            Logger = logger;
        }
        
        public virtual async UniTask InitializeAsync()
        {
            UIService = DiContainer.InstantiatePrefabForComponent<TUIService>(ModuleConfig.UIServicePrefab, parentTransform: null);
            
            await LogicService.InitializeAsync();
            await UIService.InitializeAsync();
            
            _isInitialized = true;
        }

        public virtual bool IsInitialized()
        {
            return _isInitialized;
        }

        public virtual async UniTask CloseAsync()
        {
            await UIService.CloseAsync();
            await LogicService.CloseAsync();
        }

        public virtual void Dispose()
        {
            LogicService.Dispose();
        }
        
        protected abstract string GetTag();
    }
}