using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private IEnumerator _healthChange;
    private int _speed = 1;
    private float _delay = 0.1f;

    private void Awake()
    {
        _slider.value = _slider.maxValue;
    }

    private void OnEnable()
    {
        _player.HealthBarUpdate += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.HealthBarUpdate -= OnChangeHealth;
    }

    public void OnChangeHealth()
    {
        if (_healthChange != null)
        {
            StopCoroutine(_healthChange);
            _healthChange = ChangeHealth(_player.IsChangeHealth);
            StartCoroutine(_healthChange);
        }
        else
        {
            if (_healthChange != null)
            {
                StopCoroutine(_healthChange);
            }

            _healthChange = ChangeHealth(_player.IsChangeHealth);
            StartCoroutine(_healthChange);
        }
    }

    private IEnumerator ChangeHealth(bool isChangeHealth)
    {
        int value = isChangeHealth ? _player.Damage : _player.HealHealth;

        while (value >= 0)
        {
            var _changeValue = isChangeHealth ? _slider.value - value : _slider.value + value;
            _slider.value = Mathf.MoveTowards(_slider.value, _changeValue, _speed);
            value--;
            yield return new WaitForSeconds(_delay);
        }
    }
}