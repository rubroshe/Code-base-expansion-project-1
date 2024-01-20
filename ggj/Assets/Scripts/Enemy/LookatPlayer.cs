using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float Radius;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = (this.transform.position - player.transform.position).magnitude;

        if(distance <= Radius)
        {
            this.transform.LookAt(player.transform.position);
        }
    }
}
