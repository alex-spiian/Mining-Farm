using MiningFarm.Common.Enums;

namespace MiningFarm.Common.Signals
{
    public class CloseWindowSignal
    {
        public WindowType WindowType {get; private set;}
        
        public CloseWindowSignal(WindowType windowType)
        {
            WindowType = windowType;
        }
    }
}