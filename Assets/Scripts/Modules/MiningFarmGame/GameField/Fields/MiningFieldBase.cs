using System.Collections.Generic;
using Core.Logger;
using UnityEngine;

namespace MiningFarm.Game
{
    public abstract class MiningFieldBase : LoggableMonoBehaviour
    {
        [SerializeField] private List<GameFieldSlot> _slots;
        
        public void Initialize()
        {
            foreach (var slot in _slots)
            {
                slot.Initialize();
            }
        }

        public MiningMachineBase SetSlot(MiningMachineBase machine)
        {
            var emptySlot = _slots.Find(slot => slot.IsEmpty);
            if (emptySlot == null)
            {
                Logger.Log("No empty slot found", Tag);
                return null;
            }
            
            return emptySlot.SetMachine(machine);
        }
    }
}