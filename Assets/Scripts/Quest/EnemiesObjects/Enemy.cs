using UnityEngine;
using Zenject;

namespace Quest.EnemiesObjects
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigibody;
        [Inject] protected CurrentQuests _playerQuest;
    }
}