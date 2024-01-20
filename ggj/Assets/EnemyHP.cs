using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    private float enemyHealth;

    [Header("Health Prefab")]
    [Space]
    [SerializeField] GameObject Health_Obj;

    [Header("Slider HP")]
    [Space]
    [SerializeField] Slider hpSlider;

    [Header("Damage From Vines")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromPlayer;

    [Header("Health Pickup Total")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float healthPickupTotal;

    void Start()
    {
        enemyHealth = 100;
        hpSlider.maxValue = enemyHealth;
    }
  
    public void TakeDamageFromPlayer()
    {
        enemyHealth = enemyHealth - damageFromPlayer;
    }

    public void AddHealthPickup()
    {
        enemyHealth = enemyHealth + healthPickupTotal;
    }

    private void Update()
    {
        hpSlider.value = enemyHealth;

        if(enemyHealth <= 0)
        {
            GameObject cloneHP = Instantiate(Health_Obj.gameObject, this.transform.position, Quaternion.Euler(this.transform.rotation.eulerAngles));
            GameObject.Destroy(this.gameObject);
        }
    }
}
