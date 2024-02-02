using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_PlayerHealth : MonoBehaviour
{
    public Player playerHealth;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = playerHealth.playerHP; // what do i put here
    }
}
