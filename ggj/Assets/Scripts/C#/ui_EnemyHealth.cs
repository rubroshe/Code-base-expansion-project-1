using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_EnemyHealth : MonoBehaviour
{
    public EnemyHealth _enemyHealth;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = _enemyHealth.enemyHealth;
    }
}
