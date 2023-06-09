using ObjectToQuest;
using ObjectToQuest.KillNPC;
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
            
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.AttackHero();
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