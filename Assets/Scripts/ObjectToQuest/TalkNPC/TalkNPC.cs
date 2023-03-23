﻿using Quest;
using UnityEngine;
using Zenject;

namespace ObjectToQuest
{
    public abstract class TalkNPC : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [Inject] protected PlayerQuest _playerQuest;

        public abstract void Talk();
    }
}