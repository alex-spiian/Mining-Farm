using Core.Logger;
using MiningFarm.Core;
using MiningFarm.Core.Base;
using MiningFarm.WindowService;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSingleNonLazy();
            BindSingle();
            BindTransient();
        }

        private void BindSingleNonLazy()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>().AsSingle().NonLazy();
        }

        private void BindSingle()
        {
            Container.BindInterfacesAndSelfTo<WindowsLogicService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CustomLogger>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveDataService>().AsSingle();
        }

        private void BindTransient()
        {
            Container.BindInterfacesAndSelfTo<UIInputHandler>().AsTransient();
        }
    }
}