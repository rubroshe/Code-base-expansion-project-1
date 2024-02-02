using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - player.transform.position;
        cameraOffset.y += 0.8f;
        cameraOffset.z += 5.8f;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
    /*void Update()
    {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 6.5f, player.transform.position.z - 5.5f);
    }*/
}
