using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 7.5f);
    }
}
