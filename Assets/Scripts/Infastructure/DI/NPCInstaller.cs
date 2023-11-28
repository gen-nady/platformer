using NPC;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class NPCInstaller : MonoInstaller
    {
        [SerializeField] private NPCUI _npcUI;
        
        public override void InstallBindings()
        {
            Container.Bind<NPCUI>().FromInstance(_npcUI).AsSingle();
        }
    }
}