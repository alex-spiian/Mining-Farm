using MiningFarm.Core.Base.Configs;
using MiningFarm.Core.Base.Interfaces;
using MiningFarm.Core.Base.Logic;
using MiningFarm.Core.Base.UI;
using Zenject;

namespace MiningFarm.Core.Base.Bridge
{
    public abstract class BridgeServiceWithArgsBase<TLogicService, TUIService, TModuleConfig> : BridgeServiceBase<TLogicService, TUIService, TModuleConfig>, IModuleArgsSetter
        where TModuleConfig : ModuleConfigBase 
        where TUIService : UIServiceBase
        where TLogicService : LogicServiceBase
    {
        public BridgeServiceWithArgsBase(DiContainer diContainer, TLogicService logicService, TModuleConfig moduleConfig) 
            : base(diContainer, logicService, moduleConfig)
        {
        }

        public abstract void SetArgs(object args);
    }
}