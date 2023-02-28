using UnityEngine;
using Zenject;

namespace Quest.FoundObjects
{
    public abstract class Found : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigibody;
        [Inject] protected CurrentQuests _playerQuest;
    }
}