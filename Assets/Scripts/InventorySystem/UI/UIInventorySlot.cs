using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.UI
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private ItemType _typeItem;
        public InventorySlot slot { get; private set; }
        private UIInventory _uiInventory;

        private void OnEnable()
        {
            _uiInventory = GetComponentInParent<UIInventory>();
            if (_typeItem != ItemType.None)
                slot = new InventorySlot();
        }

        public void SetSlot(InventorySlot newSlot)
        {
            slot = newSlot;
        }
        
        public override void OnDrop(PointerEventData eventData)
        {
            var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
            var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();
            var otherSlot = otherSlotUI.slot;
            var inventory = _uiInventory._inventory;
            if (_typeItem != ItemType.None && _typeItem != otherItemUI.item.info.Type ) return;
            if (_typeItem is ItemType.Trash)
            {
                inventory.Remove(this, otherSlot);
            }
            else
            {
                inventory.TransitFromSlotToSlot(this, otherSlot, slot);
            }
            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if (slot != null)
            {
                _uiInventoryItem.Refresh(slot);
            }
        }
    }
}