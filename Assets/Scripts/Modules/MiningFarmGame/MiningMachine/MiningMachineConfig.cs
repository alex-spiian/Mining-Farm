using MiningFarm.Enums;
using UnityEngine;

namespace MiningFarm.Game
{
    [CreateAssetMenu(fileName = "MiningMachineConfig", menuName = "ScriptableObject/MiningFarmGame/MiningMachineConfig")]
    public class MiningMachineConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private MiningMachineType _miningMachineType;
        [SerializeField] private float _price;
        [SerializeField] private float _miningAmountBase;
        [SerializeField] private float _miningTimeBase;
        [SerializeField] private MiningMachineBase _prefab;

        public string Name => _name;
        public string Description => _description;
        public MiningMachineType MiningMachineType => _miningMachineType;
        public float Price => _price;
        public float MiningAmountBase => _miningAmountBase;
        public float MiningTimeBase => _miningTimeBase;
        public MiningMachineBase Prefab => _prefab;
    }
}