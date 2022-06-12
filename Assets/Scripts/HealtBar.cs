using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Slider _healtBar;
    [SerializeField] private Health _health;

    private const float _minimalStep = 0.02f;

    private void Start()
    {
        _healtBar.value = _health.HealthValue;
    }

    public void HPChange()
    {
        if(_healtBar.value > _health.HealthValue)
        {
            TakeDamage(_healtBar.value - _health.HealthValue);
        }
        else if(_healtBar.value < _health.HealthValue)
        {
            Heal(_health.HealthValue - _healtBar.value);
        }
    }

    private void Heal(float difference)
    {
        float target = Mathf.Clamp(_healtBar.value + difference, _healtBar.minValue, _healtBar.maxValue);
        StartCoroutine(HpChange(target));
    }

    private void TakeDamage(float difference)
    {
        float target = Mathf.Clamp(_healtBar.value - difference, _healtBar.minValue, _healtBar.maxValue);
        StartCoroutine(HpChange(target));
    }

    private IEnumerator HpChange(float target)
    {
        while (_healtBar.value != target)
        {
            _healtBar.value = Mathf.MoveTowards(_healtBar.value, target, _minimalStep);
            yield return null;
        }
    }
}