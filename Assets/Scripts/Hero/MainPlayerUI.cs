using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class MainPlayerUI : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _floatingJoystick;
        [Header("Attack")]
        [SerializeField] private Button _coolDownButton;
        [SerializeField] private Image _coolDownImage;
        [SerializeField] private TextMeshProUGUI _coolDownText;
        [Header("HealthBar")]
        [SerializeField] private List<Image> _healthBar;
        [SerializeField] private Sprite _nonHealth;
        [SerializeField] private Sprite _health;
        [Header("Money")] 
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        private float _coolDown;
        private float _currentCoolDown;
        private bool _isCoolDown;

        private void OnEnable()
        {
            MainPlayerMovement.OnLadderState += ChangeJoystick;
            HealthMainPlayer.OnHealthChanged += ChangeHealth;
            HeroData.OnAddMoney += ChangeMoney;
        }

        private void OnDisable()
        {
            MainPlayerMovement.OnLadderState -= ChangeJoystick;
            HealthMainPlayer.OnHealthChanged -= ChangeHealth;
            HeroData.OnAddMoney -= ChangeMoney;
        }

        private void Update()
        {
            if (_isCoolDown)
            {
                if (_currentCoolDown < _coolDown)
                {
                    _coolDownImage.fillAmount = 1f * (_currentCoolDown / _coolDown);
                    _currentCoolDown += Time.deltaTime;
                    _coolDownText.text = Math.Round(_coolDown - _currentCoolDown, 1).ToString();
                }
                else
                {
                    _isCoolDown = false;
                    _coolDownButton.interactable = true;
                    _coolDownImage.gameObject.SetActive(false);
                }
            }
        }

        private void ChangeHealth(int curHealth)
        {
            for (int i = 0; i < _healthBar.Count; i++)
            {
                _healthBar[i].sprite = curHealth  > i ? _health : _nonHealth;
                
            } 
        }
        private void ChangeMoney(int countMoney)
        {
            _moneyText.text = countMoney.ToString();
        }
        
        public void StartCooldDown(float coolDown)
        {
            _coolDown = coolDown;
            _currentCoolDown = 0f;
            _isCoolDown = true;
            _coolDownButton.interactable = false;
            _coolDownImage.gameObject.SetActive(true);
            _coolDownImage.fillAmount = 0f;
            _coolDownText.text = 0.ToString();
        }

        private void ChangeJoystick(bool isFreeMove)
        {
            _floatingJoystick.AxisOptions = isFreeMove ? AxisOptions.Both : AxisOptions.Horizontal;
        }
    }
}