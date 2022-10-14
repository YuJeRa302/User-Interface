using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _damage = 10;
    private int _healing = 10;
    private int _currentHealth;
    private int _minHealth = 0;
    private int _maxHealth = 100;
    private UnityEvent<int> _healthBarUpdate = new UnityEvent<int>();

    public event UnityAction<int> HealthBarUpdate
    {
        add => _healthBarUpdate.AddListener(value);
        remove => _healthBarUpdate.RemoveListener(value);
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, _minHealth, _maxHealth);
        _healthBarUpdate.Invoke(_currentHealth);
    }

    public void Healing()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _healing, _minHealth, _maxHealth);
        _healthBarUpdate.Invoke(_currentHealth);
    }
}