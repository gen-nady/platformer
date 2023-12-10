using InventorySystem;

namespace ObjectToQuest
{
    public class InvetoryPickUpItem : PickUpItem
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            item = new InventoryItem(info);
        }

        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            gameObject.SetActive(false);
        }
    }
}