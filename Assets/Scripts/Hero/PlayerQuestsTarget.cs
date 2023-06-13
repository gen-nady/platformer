using ObjectToQuest;
using OtherItem;
using UnityEngine;

namespace Hero
{
    public class PlayerQuestsTarget : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
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
        }
    }
}