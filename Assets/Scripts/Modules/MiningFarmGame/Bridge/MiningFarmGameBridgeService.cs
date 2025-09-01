using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.WindowService;

namespace MiningFarm.Game
{
    [Scene(WindowType.MiningFarmGame)]
    public class MiningFarmGameBridgeService : BridgeServiceBase<MiningFarmGameLogicService, MiningFarmGameUIService, MiningFarmGameModuleConfig>
    {
        public override async UniTask InitializeAsync()
        {
            await base.InitializeAsync();
            Logger.Log("MiningFarmGameBridgeService InitializeAsync", Tag);
        }
    }
}