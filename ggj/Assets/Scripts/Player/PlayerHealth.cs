using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;

    [SerializeField] private PlayerMovement player;

    [Header("Damage From Enemy")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemy;

    [Header("Damage From Spikes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromSpike;

    [Header("Damage From Vines")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromVines;

    [Header("Damage From Enemy Bullet")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemyBullet;

    [Header("Damage From Enemy Cloud")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemyCloud;

    [Header("Health Pickup Total")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float healthPickupTotal;

    bool hasRan;

    [SerializeField] private GameObject location;
    void Start()
    {
        playerHealth = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.isDashing)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                playerHealth = playerHealth - damageFromEnemy;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyCloud"))
        {
            playerHealth = playerHealth - damageFromEnemyCloud * Time.deltaTime;
        }
    }

    public void TakeDamageFromSpike()
    {
        playerHealth = playerHealth - damageFromSpike;
    }
    public void TakeDamageFromVines()
    {
        playerHealth = playerHealth - damageFromVines;
    }
    public void TakeDamageFromEnemyBullet()
    {
        playerHealth = playerHealth - damageFromEnemyBullet;
    }

    public void AddHealthPickup()
    {
        if(playerHealth> 100)
        {
            return;
        }
        playerHealth = playerHealth + healthPickupTotal;
    }
}
