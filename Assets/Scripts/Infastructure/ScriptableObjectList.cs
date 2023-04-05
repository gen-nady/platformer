using System.Collections.Generic;
using UnityEngine;

namespace Infastructure
{
    [CreateAssetMenu(fileName = "!Resetter", menuName = "Quest System/Resetter")]
    public class ScriptableObjectList : ScriptableObject
    {
        public List<Quest.Quest> Quests;
    }
}