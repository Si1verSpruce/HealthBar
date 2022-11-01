using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Bar : MonoBehaviour
{
    [SerializeField] private float _changeStep;
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _activeCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateValue;
    }

    public void UpdateValue()
    {
        float newValue = _player.Health / _player.MaxHealth;

        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);

        _activeCoroutine = StartCoroutine(ChangeValue(newValue));
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _changeStep * Time.deltaTime);
            yield return null;
        }
    }
}
