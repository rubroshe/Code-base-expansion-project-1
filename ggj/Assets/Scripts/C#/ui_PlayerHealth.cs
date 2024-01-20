using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_PlayerHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;

    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = playerHealth.playerHealth;
    }
}
