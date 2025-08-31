using MiningFarm.Enums;

namespace MiningFarm.Signals
{
    public class OpenWindowSignal
    {
        public WindowType WindowType {get; private set;}
        public object Args {get; private set;}
        
        public OpenWindowSignal(WindowType windowType, object args = null)
        {
            WindowType = windowType;
            Args = args;
        }
    }
}