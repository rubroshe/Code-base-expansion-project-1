using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] public float enemyHealth;

    [Header("Player Bullet Damage")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float playerBulletDamage;

    [Header("Player Cloud Damage")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float playerCloudDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHealth = enemyHealth - playerBulletDamage;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCloud"))
        {
            enemyHealth = enemyHealth - playerCloudDamage * Time.deltaTime;
        }

    }
}
