using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private UpdateHealthBar _updateHealthBar;

    [SerializeField] private int _damage = 10;
    [SerializeField] private int _healing = 10;

    private int _currentHealth;
    private int _maxHealth = 100;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage() 
    { 
        if (_currentHealth - _damage >= 0) 
        {
            _currentHealth -= _damage;
            _updateHealthBar.UpdateUI(_currentHealth);
        }
    }

    public void Healing() 
    {
        if (_currentHealth + _healing <= _maxHealth) 
        {
            _currentHealth += _healing;
            _updateHealthBar.UpdateUI(_currentHealth);
        }
    }
}