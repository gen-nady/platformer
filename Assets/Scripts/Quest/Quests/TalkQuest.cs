using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Talk Quest", menuName = "Quest System/Talk Quest")]
    public class TalkQuest : Quest
    {
        public string npcToTalk;

        public void NpcTalked(string npcName)
        {
            if (!isComplete && npcName == npcToTalk)
            {
                isComplete = true;
            }
        }
    }
}