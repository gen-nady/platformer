using System;
using OtherItem;
using UnityEngine;
using WorldItem;

namespace ObjectToQuest
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ChestPickUpItem : PickUpItem
    {
        private Rigidbody2D _rigibody;
        private BoxCollider2D _boxColider;
        private ChestItem _chestItem;
        private bool _isDetectedCollision;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            _rigibody = GetComponent<Rigidbody2D>();
            _boxColider = GetComponent<BoxCollider2D>();
        }
        
        public void OpenChest()
        {
            _chestItem = new ChestItem(_rigibody);
            _chestItem.SpawnItem();
        }
        
        public override void PickUp()
        {
            if(_idName != string.Empty)
            {
                _playerQuest.ObjectFound(_idName);
            }
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(_isDetectedCollision) return;
            if (col.gameObject.GetComponent<Wall>())
            {
                _isDetectedCollision = true;
                _rigibody.velocity = Vector2.zero;
                _rigibody.freezeRotation = true;
                _rigibody.isKinematic = true;
                _boxColider.isTrigger = true;
            }
        }
    }
}