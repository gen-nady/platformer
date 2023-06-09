using UnityEngine;

namespace WorldItem
{
    public class DestroyerWall : MonoBehaviour
    {
        [SerializeField] private Transform _playerPositionSpawn;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                col.GetComponent<Transform>().transform.position = _playerPositionSpawn.position;
            }
        }
    }
}