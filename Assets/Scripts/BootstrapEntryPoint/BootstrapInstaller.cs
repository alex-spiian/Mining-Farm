using Core.Logger;
using MiningFarm.WindowService;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<WindowsLogicService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CustomLogger>().AsSingle();
        }
    }
}