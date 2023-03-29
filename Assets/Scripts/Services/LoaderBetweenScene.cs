using System;
using Hero;
using OtherItem;
using Quest;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Services
{
    public class LoaderBetweenScene : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [SerializeField] public Vector3 _heroPosition;
        private void Awake()
        {
            // var sceneContext = Resources.Load<SceneContext>("SceneContext");
            // var hero = Resources.Load<GameObject>("Hero");
            // var movementUI = Resources.Load<HeroAttackUI>("MovementUI");
            // var playerQuestUI = Resources.Load<PlayerQuestUI>("PlayerQuestUI");
            // var questGiverUI = Resources.Load<QuestGiverUI>("QuestGiverUI");
            // var talkQuestUI = Resources.Load<TalkQuestUI>("TalkQuestUI");
            // var worldInfoUI = Resources.Load<WorldInfoUI>("WorldInfoUI");
            // var eventSystem = Resources.Load<WorldInfoUI>("EventSystem");
            // var gameBootLoader = Resources.Load<WorldInfoUI>("GameBootLoader");
            //
            //
            // Instantiate(sceneContext);
            // Instantiate(hero,_heroPosition,quaternion.identity);
            // Instantiate(movementUI);
            // Instantiate(playerQuestUI);
            // Instantiate(questGiverUI);
            // Instantiate(talkQuestUI);
            // Instantiate(worldInfoUI);  
            // Instantiate(eventSystem);
            // Instantiate(gameBootLoader);
        }
    }
}