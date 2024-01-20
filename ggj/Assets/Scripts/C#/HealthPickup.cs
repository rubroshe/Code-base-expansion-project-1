using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] public PlayerHealth playerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("HealthPickup"))
        {
            playerHealth.AddHealthPickup();
            Destroy(collision.gameObject);
        }
    }
}
