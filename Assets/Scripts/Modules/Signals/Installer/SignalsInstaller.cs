using Zenject;

namespace MiningFarm.Signals
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<CloseWindowSignal>().RequireSubscriber();
            Container.DeclareSignal<OpenWindowSignal>().RequireSubscriber();
        }
    }
}