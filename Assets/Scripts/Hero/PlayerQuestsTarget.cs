using ObjectToQuest;
using OtherItem;
using UnityEngine;

namespace Hero
{
    public class PlayerQuestsTarget : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PickUpItem>())
            {
                other.GetComponent<PickUpItem>().PickUp();
                return;
            }
            
            if (other.GetComponent<TalkNPC>())
            {
                other.GetComponent<TalkNPC>().Talk();
                return;
            }
            
            if (other.GetComponent<TableInfo>())
            {
                other.GetComponent<TableInfo>().ShowText();
                return;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<TableInfo>())
            {
                other.GetComponent<TableInfo>().CloseText();
                return;
            }
        }
    }
}