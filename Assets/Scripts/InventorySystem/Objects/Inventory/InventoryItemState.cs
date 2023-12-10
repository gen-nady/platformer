namespace InventorySystem.Objects
{
    public class InventoryItemState
    {
        public int ItemAmount;
        public bool IsItemEquipped;
        public int amount { get => ItemAmount; set => ItemAmount = value; }
        public bool isEquipped { get => IsItemEquipped; set => IsItemEquipped = value; }

        public InventoryItemState()
        {
            ItemAmount = 1;
            IsItemEquipped = false;
        }
    }
}