using Core.Logger;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiningFarm.Game
{
    public class GameFieldSlot : LoggableMonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Transform _miningMachineSpawnPoint;
        [SerializeField] private GameObject _slotVisual;

        public bool IsEmpty { get; private set; }

        public void Initialize()
        {
            IsEmpty = true;
            _slotVisual.SetActive(IsEmpty);
        }

        public void SetMachine(GameObject machinePrefab)
        {
            Instantiate(machinePrefab, _miningMachineSpawnPoint);
            IsEmpty = false;
            _slotVisual.SetActive(IsEmpty);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsEmpty)
            {
                Logger.Log("Slot clicked → Open Shop", Tag);
            }
        }
    }
}