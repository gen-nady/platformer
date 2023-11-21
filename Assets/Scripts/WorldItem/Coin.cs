using DG.Tweening;
using Hero;
using UnityEngine;

namespace WorldItem
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private int _moneyCount;
        private Sequence _sequence;
        
        private void OnEnable()
        {
            _sequence = DOTween.Sequence();
            _sequence = _sequence.Append(_transform.DOScale(new Vector3(0.15f, 0.15f, 0.15f), 0.5f))
                .Append(_transform.DOScale(new Vector3(0.25f, 0.25f, 0.25f), 0.5f))
                .SetLoops(-1);
            _sequence.Play();
        }

        private void OnDisable()
        {
            _sequence.Kill();
        }

        public void PickUp()
        {
            HeroData.AddMoney(_moneyCount);
            gameObject.SetActive(false);
        }
    }
}