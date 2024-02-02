using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vinedamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vines"))
        {
            player.TakeDamageFromVines();
        }
    }
}