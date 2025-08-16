using UnityEngine;

namespace MiningFarm.Core.Base
{
    public abstract class ModuleConfigBase : ScriptableObject
    {
        [SerializeField] private GameObject _uiServicePrefab;
        
        public GameObject UIServicePrefab => _uiServicePrefab;
    }
}