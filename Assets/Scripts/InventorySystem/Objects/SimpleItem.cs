namespace InventorySystem
{
    public class SimpleItem : PickUpItem
    {
        private void OnEnable()
        {
            item = new InventoryItem(info);
        }
    }
}