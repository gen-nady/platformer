using UnityEngine;

namespace WorldItem
{
    public class ChestItem
    {
        private Rigidbody2D _rigidbody2D;
        private const float _minForce = 1f;
        private const float _maxForce = 2f;

        public ChestItem(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }
        
        public void SpawnItem()
        {
            var direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}