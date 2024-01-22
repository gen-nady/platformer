using ObjectToQuest;
using OtherItem;
using UnityEngine;
using WorldItem;

namespace Hero
{
    public class PlayerTarget : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<InvetoryPickUpItem>(out var invetory))
            {
                return;
            }
            
            if (other.TryGetComponent<Coin>(out var coin))
            {
                coin.PickUp();
                return;
            }
            
            if (other.TryGetComponent<PickUpItem>(out var pickUp))
            {
                pickUp.PickUp();
                return;
            }
            
            if (other.TryGetComponent<TalkNPC>(out var talk))
            {
                talk.Talk();
                return;
            }
            
            if (other.TryGetComponent<TableInfo>(out var table))
            {
                table.ShowText();
                return;
            }
            
            if (other.TryGetComponent<BigInfo>(out var bigTable))
            {
                bigTable.ShowText();
                return;
            }
            
            if (other.TryGetComponent<ObjectToQuest.Enemy>(out var enemy))
            {
                enemy.TakeDamage();
                return;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<TableInfo>(out var table))
            {
                table.CloseText();
                return;
            }
            if (other.TryGetComponent<BigInfo>(out var bigTable))
            {
                bigTable.CloseText();
                return;
            }
        }
    }
}