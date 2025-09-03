using MiningFarm.Enums;

namespace MiningFarm.Signals
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