using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UIInventoryItem : UIItem
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Image _imageIcon;
        [SerializeField] private TextMeshProUGUI _textAmount;
        
        public InventoryItem item { get; private set; }
        
        public void Refresh(InventorySlot slot)
        {
            if (slot.isEmpty)
            {
                CleanUp();
                return;
            }
            _panel.SetActive(true);
            item = slot.item;
            _imageIcon.sprite = item.info.spriteIcon;
            _textAmount.text = $"x{slot.amount}";
        }

        private void CleanUp()
        {
            _panel.SetActive(false);
        }
    }
}