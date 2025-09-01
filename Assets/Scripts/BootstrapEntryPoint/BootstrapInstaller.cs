using Core.Logger;
using MiningFarm.Core;
using MiningFarm.Core.Base;
using MiningFarm.Login;
using MiningFarm.WindowService;
using UnityEngine;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoginModuleConfig _loginModuleConfig;

        public override void InstallBindings()
        {
            BindConfigs();
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
            
            Container.BindInterfacesAndSelfTo<LoginBridgeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoginLogicService>().AsSingle();
        }

        private void BindTransient()
        {
            Container.BindInterfacesAndSelfTo<UIInputHandler>().AsTransient();
        }
        
        private void BindConfigs()
        {
            Container.BindInstance(_loginModuleConfig).AsSingle();
        }
    }
}