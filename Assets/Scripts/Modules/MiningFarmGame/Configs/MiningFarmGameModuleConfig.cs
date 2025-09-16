using MiningFarm.Core.Base;
using UnityEngine;

namespace MiningFarm.Game
{
    [CreateAssetMenu(fileName = "MiningFarmGameModuleConfig", menuName = "ScriptableObject/MiningFarmGame/MiningFarmGameModuleConfig")]
    public class MiningFarmGameModuleConfig : ModuleConfigBase
    {
        [SerializeField] private MiningFieldContainer _miningFieldContainer;
        
        public MiningFieldContainer MiningFieldContainer => _miningFieldContainer;
    }
}