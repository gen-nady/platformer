using UnityEngine;

namespace WorldItem
{
    public class Ladder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<MainPlayerMovement>(out var player))
            {
                player.SetLadder(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<MainPlayerMovement>(out var player))
            {
                player.SetLadder(false);
            }
        }
    }
}