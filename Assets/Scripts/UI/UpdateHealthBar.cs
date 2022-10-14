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

    public void OnChangeHealth(int target)
    {
        if (_healthChange != null)
        {
            StopCoroutine(_healthChange);
        }

        _healthChange = ChangeHealth(target);
        StartCoroutine(_healthChange);
    }

    private IEnumerator ChangeHealth(int target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speed);
            yield return new WaitForSeconds(_delay);
        }
    }
}