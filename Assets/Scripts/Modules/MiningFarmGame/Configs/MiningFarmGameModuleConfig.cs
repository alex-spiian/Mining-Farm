using MiningFarm.Core.Base;
using UnityEngine;

namespace MiningFarm.Game
{
    [CreateAssetMenu(fileName = "MiningFarmGameModuleConfig", menuName = "ScriptableObject/MiningFarmGame/MiningFarmGameModuleConfig")]
    public class MiningFarmGameModuleConfig : ModuleConfigBase
    {
        [SerializeField] private MiningFieldContainer _miningFieldContainer;
        [SerializeField] private MiningMachineContainer _miningMachineContainer;
        
        public MiningFieldContainer MiningFieldContainer => _miningFieldContainer;
        public MiningMachineContainer MiningMachineContainer => _miningMachineContainer;
    }
}