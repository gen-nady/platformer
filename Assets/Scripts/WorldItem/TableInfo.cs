using UnityEngine;
using Zenject;

namespace OtherItem
{
    public class TableInfo : MonoBehaviour
    {
        [SerializeField] private string _text;
        [Inject] private WorldInfoUI _worldInfoUI;

        public void ShowText()
        {
            _worldInfoUI.ShowTableInfoPanel(_text);
        }

        public void CloseText()
        {
            _worldInfoUI.CloseTableInfoPanel();
        }
    }
}