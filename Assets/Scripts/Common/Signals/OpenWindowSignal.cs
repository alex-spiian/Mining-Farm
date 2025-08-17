using MiningFarm.Common.Enums;

namespace MiningFarm.Common.Signals
{
    public class OpenWindowSignal
    {
        public WindowType WindowType {get; private set;}
        public object Args {get; private set;}
        
        public OpenWindowSignal(WindowType windowType, object args)
        {
            WindowType = windowType;
            Args = args;
        }
    }
}