using System;
using InventorySystem.UI;
using OtherItem;
using UnityEngine;
using Zenject;

namespace InventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int _inventoryCapacity = 14;
        private InventoryWithSlots _inventory;
        private UIInventory _uiInventory;
        private WorldInfoUI _worldInfoUI;
        private const string PICKUP = "Pick Up";
        
        [Inject]
        private void Construct(UIInventory uiInventory, WorldInfoUI worldInfoUI)
        {
            _uiInventory = uiInventory;
            _worldInfoUI = worldInfoUI;
        }
        private void Awake()
        {
            _inventory = new InventoryWithSlots(_inventoryCapacity);
            _uiInventory.SetInventory(_inventory);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<ObjectToQuest.PickUpItem>(out var pickUp))
            {
                _worldInfoUI.OpenButtonActionPanel(() => PickUpItem(pickUp), PICKUP);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<ObjectToQuest.PickUpItem>(out var pickUp))
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }

        private void PickUpItem(ObjectToQuest.PickUpItem pickUp)
        {
            _inventory.TryToAdd(this, pickUp.item);
            pickUp.PickUp();
            _worldInfoUI.CloseButtonActionPanel();
        }
    }
}