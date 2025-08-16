using UnityEngine;

namespace MiningFarm.Core.Base.Configs
{
    public abstract class ModuleConfigBase : ScriptableObject
    {
        [SerializeField] private GameObject _uiServicePrefab;
        
        public GameObject UIServicePrefab => _uiServicePrefab;
    }
}