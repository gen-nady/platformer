using PickUpObject;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Search Quest", menuName = "Quest System/Search Quest")]
    public class SearchQuest : Quest
    {
        public PickUpItem typeToFind;

        public void ObjectFound(PickUpItem objectFind)
        {
            if (!isComplete && objectFind is PickUpItem)
            {
                isComplete = true;
            }
        }
    }
}