using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] private float speed;

    [SerializeField] private GameObject AOE;

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
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(AOE, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
