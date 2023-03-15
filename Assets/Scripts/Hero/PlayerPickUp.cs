using PickUpObject;
using UnityEngine;

namespace Hero
{
    public class PlayerPickUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PickUpItem>())
            {
                other.GetComponent<PickUpItem>().PickUp();
            }
        }
    }
}