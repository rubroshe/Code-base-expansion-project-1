using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private GameObject respawn;
    [SerializeField] private PlayerHealth player;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spikes"))
        {
            gameObject.transform.position = new Vector3(respawn.transform.position.x, respawn.transform.position.y,
                respawn.transform.position.z);

            player.TakeDamageFromSpike();
        }
    }
}
