using InventorySystem.Objects;
using UnityEngine;

namespace InventorySystem
{
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected InventoryItemInfo info;
        public InventoryItem item { get; protected set; }
    }
}