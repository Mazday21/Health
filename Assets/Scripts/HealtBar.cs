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
    private Coroutine _hPChange;

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
        if (_hPChange != null)
        {
            StopCoroutine(_hPChange);
        }
        _hPChange = StartCoroutine(HpChange(health));
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