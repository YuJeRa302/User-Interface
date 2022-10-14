using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _healing = 10;

    private UnityEvent _healthBarUpdate = new UnityEvent();
    private int _currentHealth;
    private int _maxHealth = 100;

    public event UnityAction HealthBarUpdate
    {
        add => _healthBarUpdate.AddListener(value);
        remove => _healthBarUpdate.RemoveListener(value);
    }

    public bool IsChangeHealth { get; private set; }
    public int Damage { get; private set; }
    public int HealHealth { get; private set; }

    private void Awake()
    {
        Damage = _damage;
        HealHealth = _healing;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        if (_currentHealth - _damage >= 0)
        {
            IsChangeHealth = true;
            _currentHealth -= _damage;
        }

        _healthBarUpdate.Invoke();
    }

    public void Healing()
    {
        if (_currentHealth + _healing <= _maxHealth)
        {
            IsChangeHealth = false;
            _currentHealth += _healing;
        }

        _healthBarUpdate.Invoke();
    }
}