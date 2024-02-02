using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelelportToLevelTwo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Teleport;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = Teleport.transform.position;
        }
    }
}
