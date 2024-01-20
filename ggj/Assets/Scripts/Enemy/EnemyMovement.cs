using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Header("Enemy Attributes")]
    [Space]
    [Range(0.0F, 25.0F)]
    [SerializeField] private float speed;
    [Range(0.0F, 10.0F)]
    [SerializeField] private float Radius_Avoidance;

    [SerializeField] private Animator Ai_Anim;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = (this.transform.position - player.transform.position).magnitude;

        if(distance <= Radius_Avoidance)
        {
            Ai_Anim.SetBool("Walk", true);
            navMeshAgent.destination = player.transform.position;
            Debug.Log("Distance: " + distance);
        }

    }


}
