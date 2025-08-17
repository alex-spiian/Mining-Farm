using MiningFarm.Common.Enums;
using MiningFarm.Core.Base;

namespace MiningFarm.WindowService
{
    public sealed class Metadata
    {
        public readonly WindowType Type;
        public IModuleInitializeAsync ModuleComponent;
        public readonly object Args;
        public bool IsNeedToClose;

        public Metadata(WindowType type, object args)
        {
            Type = type;
            Args = args;
            ModuleComponent = null;
            IsNeedToClose = false;
        }
    }
}