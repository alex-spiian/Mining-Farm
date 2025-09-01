using UnityEngine;
using Zenject;

namespace MiningFarm.Game
{
    public class MiningFarmGameInstaller : MonoInstaller
    {
        [SerializeField] private MiningFarmGameModuleConfig _miningFarmGameModuleConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MiningFarmGameBridgeService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MiningFarmGameLogicService>().AsSingle();
            
            Container.BindInstance(_miningFarmGameModuleConfig).AsSingle();
        }
    }
}