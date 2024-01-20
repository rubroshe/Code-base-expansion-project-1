using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAOE : MonoBehaviour
{
    [SerializeField] private GameObject AOEBall;
    [SerializeField] private GameObject BallSpawnLocation;

    private bool isReadyToShoot;

    float timer;

    [Header("Bullet Min Time")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float minTime;

    [Header("Bullet Max Time")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float maxTime;

    private void Awake()
    {
        timer = Random.Range(minTime, maxTime);
    }
    private void Start()
    {
        isReadyToShoot = true;
    }

    void Update()
    {
        if(timer < 0)
        {
            timer = Random.Range(2, 5);
            isReadyToShoot = true;
        }
        timer -= Time.deltaTime;

        if (isReadyToShoot)
        {
            Instantiate(AOEBall, new Vector3(BallSpawnLocation.transform.position.x, transform.position.y + 2f,
                BallSpawnLocation.transform.position.z), this.transform.rotation);
            isReadyToShoot = false;
        }
    }
}