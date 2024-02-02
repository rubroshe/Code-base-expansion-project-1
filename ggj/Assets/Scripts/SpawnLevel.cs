using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    [Header("Spawn Level Two & Door")]
    [Space]
    [SerializeField] private GameObject LevelTwo;
    [SerializeField] private GameObject DoorLeftMostRoom;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            LevelTwo.SetActive(true);
            DoorLeftMostRoom.SetActive(true);
        }
    }
}
