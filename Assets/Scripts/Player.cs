using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _healthChanged = new UnityEvent();

    public float MaxHealth => _maxHealth;
    public float Health => _health;
    public event UnityAction HealthChanged
    {
        add => _healthChanged.AddListener(value);
        remove => _healthChanged.RemoveListener(value);
    }

    public void TakeDamage(float value)
    {
        float newHealth = _health - value;

        ChangeHealth(newHealth);
    }

    public void TakeHealing(float value)
    {
        float newHealth = _health + value;

        ChangeHealth(newHealth);
    }

    private void ChangeHealth(float value)
    {
        _health = Mathf.Clamp(value, 0, _maxHealth);

        _healthChanged.Invoke();
    }
}
