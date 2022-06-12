using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _hPIncrease;
    [SerializeField] private Button _hPDecrease;

    private const float _step = 2f;
    private const float _minimalStep = 0.02f;
    private const float _minValueHP = 0;
    private const float _maxValueHP = 20f;

    public float HealthValue { get; private set; }
    public bool IsHealthChange { get; private set; }

    private void Start()
    {
        HealthValue = _maxValueHP / 2f;
        _hPIncrease.onClick.AddListener(Heal);
        _hPDecrease.onClick.AddListener(TakeDamage);
    }

    private void Heal()
    {
        float target = Mathf.Clamp(HealthValue + _step, _minValueHP, _maxValueHP);
        StartCoroutine(HpChange(target));
    }

    private void TakeDamage()
    {
        float target = Mathf.Clamp(HealthValue - _step, _minValueHP, _maxValueHP);
        StartCoroutine(HpChange(target));
    }

    private IEnumerator HpChange(float target)
    {
        IsHealthChange = true;

        while (HealthValue != target)
        {
            HealthValue = Mathf.MoveTowards(HealthValue,target, _minimalStep);
            yield return null;
        }
        IsHealthChange = false;
    }
}
