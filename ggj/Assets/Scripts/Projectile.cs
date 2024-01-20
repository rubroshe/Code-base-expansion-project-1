using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float speed;
    [Range(0.0f, 10.0f)]
    [SerializeField] private float DespawnBullet_Default;

    private void Awake()
    {
        StartCoroutine(DeleteProjectile());
    }

    void Update()
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject.Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    IEnumerator DeleteProjectile()
    {
        yield return new WaitForSeconds(DespawnBullet_Default);

        GameObject.Destroy(this.gameObject);
    }

}
