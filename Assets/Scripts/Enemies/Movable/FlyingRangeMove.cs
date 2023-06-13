using Enemy.Interface;
using UnityEngine;

namespace Enemy.Movable
{
    public class FlyingRangeMove : IMovable
    {
        private readonly Transform _transform;
        private readonly Transform _targetTransform;
        
        public FlyingRangeMove(Transform transform, Transform targetTransform)
        {
            _transform = transform;
            _targetTransform = targetTransform;
        }
        
        public void Move(float speed)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _targetTransform.position, speed * Time.deltaTime);
        }
    }
}