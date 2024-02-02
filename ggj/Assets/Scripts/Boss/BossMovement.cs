using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    [Header("Speed of Enemy")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float enemySpeed;

    Rigidbody rb;

    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = (this.transform.position - player.transform.position).magnitude;

        if(distance > 5)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.01f);
        }

    }
}
