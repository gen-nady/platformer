using UnityEngine;

namespace InventorySystem.Objects
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Inventory/Item", order = 0)]
    public class InventoryItemInfo : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _maxItemsInInventoruSlot;
        [SerializeField] private Sprite _spriteIco;
        public string id => _id;
        public string title => _title;
        public string description => _description;
        public int maxItemInInventorySlot => _maxItemsInInventoruSlot;
        public Sprite spriteIcon => _spriteIco;
    }
}