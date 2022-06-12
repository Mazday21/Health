using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _healtBar;

    private Health _playerHealth;
    
    private void Start()
    {
        _playerHealth = _player.GetComponent<Health>();
    }

    
    private void Update()
    {
        _healtBar.value = _playerHealth.HealthValue;
    }
    //sfgvsr
}