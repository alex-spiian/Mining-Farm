using MiningFarm.Core.Base;
using UnityEngine;

namespace MiningFarm.Login
{
    [CreateAssetMenu(fileName = "LoginModuleConfig", menuName = "ScriptableObject/Login/LoginModuleConfig")]
    public class LoginModuleConfig : ModuleConfigBase
    {
        [SerializeField] private float _fakeLoadingDuration;
        
        public float FakeLoadingDuration => _fakeLoadingDuration;
    }
}