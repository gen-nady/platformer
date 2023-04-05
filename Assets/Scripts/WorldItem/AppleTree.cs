using System;
using System.Collections.Generic;
using System.Linq;
using ObjectToQuest;
using OtherItem;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace WorldItem
{
    public class AppleTree : MonoBehaviour
    {
        [SerializeField] private List<ApplePickUpItem> _apples;
        private WorldInfoUI _worldInfoUI;
        
        [Inject]
        private void Construct(WorldInfoUI worldInfoUI)
        {
            _worldInfoUI = worldInfoUI;
        }

        private void ShakeTree()
        {
            var randomApple = Random.Range(0, _apples.Count-1);
            _apples[randomApple].EnablePhysics();
            _apples.RemoveAt(randomApple);
            if (_apples.Count == 0 && _apples.All(_ => !_.isActiveAndEnabled))
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                if(_apples.Count == 0 || _apples.All(_ => !_.isActiveAndEnabled)) return;
                _worldInfoUI.OpenButtonActionPanel(ShakeTree);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.GetComponent<MainPlayerMovement>())
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }
    }
}