using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class BridgeServiceBase<TLogicService, TUIService, TModuleConfig> 
        : IModuleInitializeAsync,
        IDisposable,
        IInitializable
        where TLogicService : LogicServiceBase 
        where TUIService : UIServiceBase
        where TModuleConfig : ModuleConfigBase
    {
        /// <summary>
        /// Determines whether this module should automatically run <see cref="InitializeAsync"/> 
        /// when constructed by Zenject. 
        /// If set to <c>true</c>, the module will be initialized eagerly (non-lazy) in the module installer.
        /// </summary>
        protected virtual bool IsAutoInitialize { get; set; } = false;

        protected DiContainer DiContainer;
        protected SignalBus SignalBus;
        
        protected TLogicService LogicService;
        protected TUIService UIService;
        protected TModuleConfig ModuleConfig;
        protected ICustomLogger Logger { get; set; }
        protected virtual string Tag => GetType().Name;
        
        private bool _isInitialized;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            TLogicService logicService,
            TModuleConfig moduleConfig,
            SignalBus signalBus,
            ICustomLogger logger
            )
        {
            DiContainer = diContainer;
            LogicService = logicService;
            ModuleConfig = moduleConfig;
            SignalBus = signalBus;
            Logger = logger;
        }
        
        public void Initialize()
        {
            if (IsAutoInitialize)
                InitializeAsync().Forget();
        }

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
            await UIService.CloseAsync();
            await LogicService.CloseAsync();
        }

        public virtual void Dispose()
        {
            Unsubscribe();
            LogicService.Dispose();
            UIService.Dispose();
        }
        
        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }
    }
}