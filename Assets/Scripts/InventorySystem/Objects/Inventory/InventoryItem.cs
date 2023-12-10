using System;
using InventorySystem.Objects;

namespace InventorySystem
{
    public class InventoryItem 
    {
        public InventoryItemInfo info { get; }
        public InventoryItemState state { get; }
        //public Type type => GetType();

        public InventoryItem(InventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }

        public InventoryItem Clone()
        {
            var clonned = new InventoryItem(info);
            clonned.state.amount = state.amount;
            return clonned;
        }
    }
}