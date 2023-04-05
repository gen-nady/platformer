using UnityEngine;

namespace Infastructure
{
    [CreateAssetMenu(fileName = "SceneLoader", menuName = "Loader", order = 0)]
    public class Scenes : ScriptableObject
    {
        public Object Scene;
    }
}