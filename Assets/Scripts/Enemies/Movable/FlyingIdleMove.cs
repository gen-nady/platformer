using Enemy.Interface;
using UnityEngine;

namespace Enemy.Movable
{
    public class FlyingIdleMove : IMovable
    {
        private readonly Transform _transform;
        private readonly Vector3 _startPos;
        private readonly float _startTime;

        private const float _amplitude = 1.5f;
        private const float _frequency = 2f;

        public FlyingIdleMove(Transform transform)
        {
            _transform = transform;
            _startPos = transform.position;
            
            _startTime = Time.time;
        }
        
        public void Move(float speed)
        {
            var xOffset = Mathf.Sin((Time.time - _startTime) * _frequency) * _amplitude;
            _transform.position = _startPos + new Vector3(xOffset, 0f, 0f);
            _transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}