using System;
using System.Collections.Generic;
using MiningFarm.Enums;
using UnityEngine;

namespace MiningFarm.Game
{
    [CreateAssetMenu(fileName = "MiningFieldContainer", menuName = "ScriptableObject/MiningFarmGame/MiningFieldContainer")]
    public class MiningFieldContainer : ScriptableObject
    {
        [SerializeField] private List<MiningFieldContainerData> _fieldsData;
        
        public MiningFieldBase GetField(MiningFieldType type)
        {
            var requiredData = _fieldsData.Find(data => data.Type == type);
            return requiredData?.FieldPrefab;
        }
    }
    
    [Serializable]
    public class MiningFieldContainerData
    {
        [SerializeField] private MiningFieldType _type;
        [SerializeField] private MiningFieldBase _fieldPrefab;
        
        public MiningFieldType Type => _type;
        public MiningFieldBase FieldPrefab => _fieldPrefab;
    }
}