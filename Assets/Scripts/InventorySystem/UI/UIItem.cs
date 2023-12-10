using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.UI
{
    public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private CanvasGroup _canvasGroup;
        private Canvas _invetoryCanvas;
        private RectTransform _rectTransform;
        private const int SCALE_FACTOR = 2;
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _invetoryCanvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            var slotTransform = _rectTransform.parent;
            slotTransform.SetAsLastSibling();
            _canvasGroup.blocksRaycasts = false;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.localPosition += (Vector3)(eventData.delta) / _invetoryCanvas.scaleFactor / SCALE_FACTOR;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}