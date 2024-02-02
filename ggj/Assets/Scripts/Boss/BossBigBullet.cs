using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBigBullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] private float speed;

    [SerializeField] private GameObject AOE;

    [SerializeField] private GameObject playerFeet;

    private void Start()
    {
        playerFeet = GameObject.FindGameObjectWithTag("Feet");
        this.transform.LookAt(playerFeet.transform.rotation.eulerAngles);  
        StartCoroutine(Delete());
    }
    void Update()
    {
        this.transform.position += playerFeet.transform.position * speed * Time.deltaTime;
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(10);
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
