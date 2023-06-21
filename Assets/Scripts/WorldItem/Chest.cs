using System;
using System.Collections.Generic;
using ObjectToQuest;
using OtherItem;
using UnityEngine;
using Zenject;

namespace WorldItem
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private List<ChestPickUpItem> _chestItems;
        private const string _nameButton = "Открыть сундук";
        private bool _isOpen;
        private WorldInfoUI _worldInfoUI;
        private readonly int _onOpen = Animator.StringToHash("OnOpen");
        
        [Inject]
        private void Construct(WorldInfoUI worldInfoUI)
        {
            _worldInfoUI = worldInfoUI;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(_isOpen) return;
            
            if (col.GetComponent<MainPlayerMovement>())
            {
                _worldInfoUI.OpenButtonActionPanel(OpenChest, _nameButton);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }

        private void OpenChest()
        {
            if(_isOpen) return;
            _isOpen = true;
            _animator.SetTrigger(_onOpen);
            if (_chestItems != null)
            {
                foreach (var item in _chestItems)
                {
                    var itemCreate = Instantiate(item, transform.position, Quaternion.identity);
                    itemCreate.OpenChest();
                }
            }
        }
    }
}