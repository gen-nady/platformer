using Quest;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private PlayerQuest _playerQuest;
        [SerializeField] private PlayerQuestUI _playerQuestUI;
        [SerializeField] private QuestGiverUI _questGiverUI;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerQuest>().FromInstance(_playerQuest).AsSingle();
            Container.Bind<PlayerQuestUI>().FromInstance(_playerQuestUI).AsSingle();
            Container.Bind<QuestGiverUI>().FromInstance(_questGiverUI).AsSingle();
        }
    }
}