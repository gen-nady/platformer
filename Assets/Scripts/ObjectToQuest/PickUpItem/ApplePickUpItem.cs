using System;
using OtherItem;
using Quest;
using UnityEngine;

namespace ObjectToQuest
{
    public class ApplePickUpItem : PickUpItem
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private AppleFreshness _freshness;

        public void EnablePhysics()
        {
            _rigidbody.simulated = true;
        }
        
        public void DisablePhysics()
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }
        
        public override void PickUp()
        {
            _playerQuest.ObjectFound(_idName);
            DisablePhysics();
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Wall>())
            {
                DisablePhysics();
            }
        }
    }
}