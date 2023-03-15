﻿using System;
using Quest;
using UnityEngine;
using Zenject;

namespace PickUpObject
{
    public abstract class PickUpItem : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        [Inject] public PlayerQuest _playerQuest;

        public abstract void PickUp();
    }
}