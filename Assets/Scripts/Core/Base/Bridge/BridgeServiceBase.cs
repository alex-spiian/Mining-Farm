using Cysharp.Threading.Tasks;
using Zenject;

namespace MiningFarm.Core.Base
{
    public abstract class BridgeServiceBase<TLogicService, TUIService, TModuleConfig> : IModuleInitializeAsync 
        where TLogicService : LogicServiceBase 
        where TUIService : UIServiceBase
        where TModuleConfig : ModuleConfigBase
    {
        protected DiContainer DiContainer;
        protected TLogicService LogicService;
        protected TModuleConfig ModuleConfig;
        protected TUIService UIService;

        public BridgeServiceBase(DiContainer diContainer, TLogicService logicService, TModuleConfig moduleConfig)
        {
            DiContainer = diContainer;
            LogicService = logicService;
            ModuleConfig = moduleConfig;
        }
        
        public virtual async UniTask InitializeAsync()
        {
            UIService = DiContainer.InstantiatePrefabForComponent<TUIService>(ModuleConfig.UIServicePrefab, parentTransform: null);
            
            await LogicService.InitializeAsync();
            await UIService.InitializeAsync();
        }
    }
}