namespace MiningFarm.Core.Base
{
    public abstract class BridgeServiceWithArgsBase<TLogicService, TUIService, TModuleConfig> : BridgeServiceBase<TLogicService, TUIService, TModuleConfig>, IModuleArgsSetter
        where TModuleConfig : ModuleConfigBase 
        where TUIService : UIServiceBase
        where TLogicService : LogicServiceBase
    {
        public abstract void SetArgs(object args);
    }
}