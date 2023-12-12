using System.Collections.Generic;
using Hero;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _panelInventory;
        [SerializeField] private UIInventorySlot _uiInventorySlotPrefab;
        [SerializeField] private RectTransform _uiInventorySlotPosition;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private TextMeshProUGUI _armoorCount;
        [SerializeField] private TextMeshProUGUI _attackCount;
        private List<UIInventorySlot> _uiSlots = new List<UIInventorySlot>();
        public InventoryWithSlots _inventory { get; private set; }

        public void SetInventory(InventoryWithSlots inventory)
        {
            _inventory = inventory;
            inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
        }

        public void OpenInventory()
        {
            _panelInventory.SetActive(true);
            IntantiateInventory();
            SetupInventoryUI();
            SetStats();
        }

        public void CloseInventory()
        {
            _panelInventory.SetActive(false);
        }

        public void SetStats()
        {
            _armoorCount.text = HeroData.Armor.ToString();
            _attackCount.text = HeroData.Attack.ToString();
        }
        
        private void SetupInventoryUI()
        {
            var allSlots = _inventory.GetAllSlots();
            for (int i = 0; i < allSlots.Count; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlots[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }

        private void OnInventoryStateChanged(object sender)
        {
            if (_panelInventory.activeInHierarchy)
            { 
                foreach (var slot in _uiSlots)
                {
                    slot.Refresh();
                } 
            }
        }

        private void IntantiateInventory()
        {
            if(_inventory.capacity == _uiSlots.Count) return;
            foreach (var slot in _uiSlots)
                Destroy(slot.gameObject);
            _uiSlots.Clear();
            
           
            for (int i = 0; i < _inventory.capacity; i++)
            {
                var slot = Instantiate(_uiInventorySlotPrefab, _uiInventorySlotPosition);
                _uiSlots.Add(slot);
            }
            _gridLayoutGroup.enabled = true;
            Canvas.ForceUpdateCanvases();
            _gridLayoutGroup.enabled = false;
        }
    }
}