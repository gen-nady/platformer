using Hero;
using OtherItem;
using Quest;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private PlayerQuestUI _playerQuestUI;
        [SerializeField] private QuestGiverUI _questGiverUI; 
        [SerializeField] private WorldInfoUI _worldInfoUI;
        [SerializeField] private TalkQuestUI _talkQuestUI;
        [SerializeField] private HeroAttackUI _heroAttackUI;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerQuestUI>().FromInstance(_playerQuestUI).AsSingle();
            Container.Bind<QuestGiverUI>().FromInstance(_questGiverUI).AsSingle();  
            Container.Bind<WorldInfoUI>().FromInstance(_worldInfoUI).AsSingle();
            Container.Bind<TalkQuestUI>().FromInstance(_talkQuestUI).AsSingle();
            Container.Bind<HeroAttackUI>().FromInstance(_heroAttackUI).AsSingle();
        }
    }
}