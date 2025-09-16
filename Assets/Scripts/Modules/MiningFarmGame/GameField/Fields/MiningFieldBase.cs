using System.Collections.Generic;
using UnityEngine;

namespace MiningFarm.Game
{
    public abstract class MiningFieldBase : MonoBehaviour
    {
        [SerializeField] private List<GameFieldSlot> _slots;
        
        public void Initialize()
        {
            foreach (var slot in _slots)
            {
                slot.Initialize();
            }
        }    
    }
}