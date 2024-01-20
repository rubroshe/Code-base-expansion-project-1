using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(Delete());
    }
    void Update()
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
