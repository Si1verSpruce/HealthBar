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

    public void ChangeHealth(float value)
    {
        float newHealth = _health + value;

        if (newHealth > _maxHealth)
            _health = _maxHealth;
        else if (newHealth < 0)
            _health = 0;
        else
            _health = newHealth;

        _healthChanged.Invoke();
    }
}
