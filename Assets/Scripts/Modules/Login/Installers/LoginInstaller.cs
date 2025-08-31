using UnityEngine;
using Zenject;

namespace MiningFarm.Login
{
    public class LoginInstaller : MonoInstaller
    {
        [SerializeField] private LoginModuleConfig _loginModuleConfig;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LoginBridgeService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoginLogicService>().AsSingle();
            
            Container.BindInstance(_loginModuleConfig).AsSingle();
        }
    }
}