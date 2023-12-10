using System;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem
{
    public class InventoryWithSlots
    {
        public event Action<object, InventoryItem, int> OnInventoryItemAddedEvent;
        public event Action<object, string, int> OnInventoryItemRemovedEvent;
        public event Action<object> OnInventoryStateChangedEvent;
        public int capacity { get; set; }
        public bool isFull => _slots.All(_ => _.isFull);

        private List<InventorySlot> _slots;

        public InventoryWithSlots(int capacity)
        {
            this.capacity = capacity;
            _slots = new List<InventorySlot>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }
        
        public InventoryItem GetItem(string id)
        {
            return _slots.Find(_ => _.item.info.id == id).item;
        }

        public List<InventoryItem> GetAllItems()
        {
            return _slots.Where(_ => !_.isEmpty)
                         .Select(_ => _.item)
                         .ToList();
        }

        public List<InventoryItem> GetAllItems(string id)
        {
            return _slots.Where(_ => !_.isEmpty && _.item.info.id == id)
                         .Select(_ => _.item)
                         .ToList();
        }

        public List<InventoryItem> GetEquippedItems()
        {
            return _slots.Where(_ => !_.isEmpty && _.item.state.isEquipped)
                .Select(_ => _.item)
                .ToList();
        }

        public int GetItemAmount(string id)
        {
            return _slots.Where(_ => !_.isEmpty && _.item.info.id == id)
                .Select(_ => _.item)
                .Sum(_ => _.state.amount);
        }

        public bool TryToAdd(object sender, InventoryItem item)
        {
            var slotWithSameItemButNotEmpty = _slots.Find(_ => !_.isEmpty && _.item.info.id == item.info.id && !_.isFull);
            if (slotWithSameItemButNotEmpty != null)
                return TryAddToSlot(sender, slotWithSameItemButNotEmpty, item);
            
            var emptySlot = _slots.Find(_ => _.isEmpty);
            if (emptySlot != null)
                return TryAddToSlot(sender, emptySlot, item);
            
            return false;
        }

        private bool TryAddToSlot(object sender, InventorySlot slot, InventoryItem item)
        {
            var fits = slot.amount + item.state.amount <= item.info.maxItemInInventorySlot;
            var amountToAdd = fits ? item.state.amount : item.info.maxItemInInventorySlot - slot.amount;
            var amountLeft = item.state.amount - amountToAdd;
            var clonedItem = item.Clone();
            clonedItem.state.amount = amountToAdd;
            
            if(slot.isEmpty)
                slot.SetItem(clonedItem);
            else
                slot.item.state.amount += amountToAdd;
            
            OnInventoryStateChangedEvent?.Invoke(sender);
            OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);
            
            if (amountLeft <= 0) return true;

            item.state.amount = amountLeft;
            return TryToAdd(sender, item);
        }

        public void TransitFromSlotToSlot(object sender, InventorySlot fromSlot, InventorySlot toSlot)
        {
            if(fromSlot == toSlot) return;
            
            if(fromSlot.isEmpty) return;
            
            if(toSlot.isFull) return;
            
            if(!toSlot.isEmpty && fromSlot.item.info.id != toSlot.item.info.id) return;

            var slotcapacity = fromSlot.capacity;
            var fits = fromSlot.amount + toSlot.amount <= slotcapacity;
            var amountToAdd = fits ? fromSlot.amount : slotcapacity - toSlot.amount;
            var amountLeft = fromSlot.amount - amountToAdd;

            if (toSlot.isEmpty)
            {
                toSlot.SetItem(fromSlot.item);
                fromSlot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
            }

            toSlot.item.state.amount += amountToAdd;
            if (fits)
                fromSlot.Clear();
            else
                fromSlot.item.state.amount = amountLeft;
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
        
        public void Remove(object sender, string id, int amount = 1)
        {
            var slotsWithItem = GetAllSlots(id);
            if(slotsWithItem.Count == 0) return;

            var amountToRemove = amount;
            var count = slotsWithItem.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                var slot = slotsWithItem[i];
                if (slot.amount >= amountToRemove)
                {
                    slot.item.state.amount -= amountToRemove;
                    if (slot.amount <= 0)
                        slot.Clear();
                    OnInventoryStateChangedEvent?.Invoke(sender);
                    OnInventoryItemRemovedEvent?.Invoke(sender, id, amountToRemove);
                    break;
                }

                var amountRemoved = slot.amount;
                amountToRemove -= slot.amount;
                slot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
                OnInventoryItemRemovedEvent?.Invoke(sender, id, amountRemoved);
            }
        }

        public void Remove(object sender, InventorySlot slotDeleted)
        {
            var slotsWithDeleted =_slots.FirstOrDefault(_ => _ == slotDeleted);
            if(slotsWithDeleted == default) return;
            slotsWithDeleted.Clear();
            OnInventoryStateChangedEvent?.Invoke(sender);
            OnInventoryItemRemovedEvent?.Invoke(sender, slotsWithDeleted.item.info.id, slotsWithDeleted.item.state.amount);
        }
        
        
        public List<InventorySlot> GetAllSlots(string id)
        {
            return _slots.FindAll(_ => !_.isEmpty && _.item.info.id == id);
        }
        
        public List<InventorySlot> GetAllSlots()
        {
            return _slots;
        }

        public bool HasItem(string id, out InventoryItem item)
        {
            item = GetItem(id);
            return item != null;
        }
    }
}