using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healtBar;
    
    private void Update()
    {
        if (_health.IsHealthChange)
        {
            _healtBar.value = _health.HealthValue;
        }
    }
}
