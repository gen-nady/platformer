using System;
using Quest;
using UnityEngine;
using Zenject;

namespace NPC
{
    public class SimpleNPC : MonoBehaviour
    {
        [SerializeField] private bool _isTalk;
        [SerializeField] private bool _isQuest;
        [SerializeField] private bool _isSale;

        private QuestGiver _questGiver;
        private NPCUI _npcUI;

        [Inject]
        private void Construct(NPCUI npcUI)
        {
            _npcUI = npcUI;
        }
        
        private void OnEnable()
        {
            if (_isQuest)
                _questGiver = GetComponent<QuestGiver>();
        }

        public void TrustOpenQuest()
        {
            _questGiver.QuestControled();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<MainPlayerMovement>())
            {
                _npcUI.SetActionButtons(default, default, TrustOpenQuest);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<MainPlayerMovement>())
            {
                _npcUI.RemoveAllListener();
            }
        }
    }
}