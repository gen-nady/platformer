using System;

namespace InventorySystem
{
    public class InventorySlot
    {
        public bool isFull => !isEmpty && amount == capacity;
        public bool isEmpty => item == null; 
        public InventoryItem item { get; private set; }
        public int amount => isEmpty ? 0 : item.state.amount;
        public int capacity { get; private set; }
        public void SetItem(InventoryItem item)
        {
           if(!isEmpty) return;

           this.item = item;
           capacity = item.info.maxItemInInventorySlot;
        }

        public void Clear()
        {
            if(isEmpty) return;
            
            item.state.amount = 0;
            item = null;
        }
    }
}