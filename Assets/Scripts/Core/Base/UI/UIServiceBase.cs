using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MiningFarm.Core.Base
{
    public abstract class UIServiceBase : MonoBehaviour
    {
        public virtual async UniTask InitializeAsync()
        {
        }
    }
}