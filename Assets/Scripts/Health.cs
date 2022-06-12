using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _hPIncrease;
    [SerializeField] private Button _hPDecrease;
    [SerializeField] private Slider _hPDisplay;

    private const float _step = 2f;
    private const float _minimalStep = 0.02f;

    public float HealthValue { get; private set; }
    
    private void Start()
    {
        HealthValue = _hPDisplay.maxValue / 2f;
        _hPIncrease.onClick.AddListener(HpIncrease);
        _hPDecrease.onClick.AddListener(HpDecrease);
    }
    
    private void HpIncrease()
    {
        float target = Mathf.Clamp(HealthValue + _step, _hPDisplay.minValue, _hPDisplay.maxValue);
        StartCoroutine(HpChange(target));
    }

    private void HpDecrease()
    {
        float target = Mathf.Clamp(HealthValue - _step, _hPDisplay.minValue, _hPDisplay.maxValue);
        StartCoroutine(HpChange(target));
    }

    private IEnumerator HpChange(float target)
    { 
        if (HealthValue > target)
        {
            while (HealthValue > target)
            {
                HealthValue -= _minimalStep;
                yield return null;
            }
        }
        else if (HealthValue < target)
        {
            while (HealthValue < target)
            {
                HealthValue += _minimalStep;
                yield return null;
            }
        }
    }
}
