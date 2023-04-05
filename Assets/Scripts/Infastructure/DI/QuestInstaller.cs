using Quest;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private PlayerQuest _playerQuest;

        public override void InstallBindings()
        {
            Container.Bind<PlayerQuest>().FromInstance(_playerQuest).AsSingle();
        }
    }
}