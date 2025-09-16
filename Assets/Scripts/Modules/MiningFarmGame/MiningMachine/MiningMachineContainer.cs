using System;
using System.Collections.Generic;
using MiningFarm.Enums;
using UnityEngine;

namespace MiningFarm.Game
{
    [CreateAssetMenu(fileName = "MiningMachineContainer", menuName = "ScriptableObject/MiningFarmGame/MiningMachineContainer")]
    public class MiningMachineContainer : ScriptableObject
    {
        [SerializeField] private List<MiningMachineContainerData> _data;

        public MiningMachineConfig GetConfig(MiningMachineType type)
        {
            var requiredData = _data.Find(data => data.Type == type);
            return requiredData?.Config;
        }

        [Serializable]
        public class MiningMachineContainerData
        {
            [SerializeField] private MiningMachineType _type;
            [SerializeField] private MiningMachineConfig _config;

            public MiningMachineType Type => _type;
            public MiningMachineConfig Config => _config;
        }
    }
}