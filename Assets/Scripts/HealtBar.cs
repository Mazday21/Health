using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private const float _minimalStep = 0.02f;

    private void OnEnable()
    {
        _health.HealthChanged += HealthChange;
    }
    
    private void OnDisable()
    {
        _health.HealthChanged -= HealthChange;
    }

    private void HealthChange(float health)
    {
        if(_healthBar.value > health)
        {
            TakeDamage(_healthBar.value - health);
        }
        else if(_healthBar.value < health)
        {
            Heal(health - _healthBar.value);
        }
    }

    private void Heal(float difference)
    {
        float target = Mathf.Clamp(_healthBar.value + difference, _healthBar.minValue, _healthBar.maxValue);
        StartCoroutine(HpChange(target));
    }

    private void TakeDamage(float difference)
    {
        float target = Mathf.Clamp(_healthBar.value - difference, _healthBar.minValue, _healthBar.maxValue);
        StartCoroutine(HpChange(target));
    }

    private IEnumerator HpChange(float target)
    {
        while (_healthBar.value != target)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, target, _minimalStep);
            yield return null;
        }
    }
}