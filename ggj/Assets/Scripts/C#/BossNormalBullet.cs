using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormalBullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] private float speed;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerHealth playerHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        StartCoroutine(Delete());
    }
    void Update()
    {
        this.transform.position += player.transform.position.normalized * speed * Time.deltaTime;
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamageFromEnemyBullet();
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
