using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _hPIncrease;
    [SerializeField] private Button _hPDecrease;

    private const float _step = 2f;
    private const float _minValueHP = 0;
    private const float _maxValueHP = 20f;

    public float HealthValue { get; private set; } = _maxValueHP / 2f;

    private void Start()
    {
        _hPIncrease.onClick.AddListener(Heal);
        _hPDecrease.onClick.AddListener(TakeDamage);
    }

    private void Heal()
    {
        HealthValue = Mathf.Clamp(HealthValue + _step, _minValueHP, _maxValueHP);
    }

    private void TakeDamage()
    {
        HealthValue = Mathf.Clamp(HealthValue - _step, _minValueHP, _maxValueHP);
    }
}
