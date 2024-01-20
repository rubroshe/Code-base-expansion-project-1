using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBigAttack : MonoBehaviour
{
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private GameObject bulletSpawnLocation;

    private bool isReadyToShoot;

    [Header("Timer between shots")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float shotsTimer;

    private float timerStart;
    private void Awake()
    {
        timerStart = shotsTimer;
    }
    private void Start()
    {
        isReadyToShoot = true;
        bulletSpawnLocation = GameObject.FindGameObjectWithTag("BulletSpawnLocation");
    }

    void Update()
    {
        if (!isReadyToShoot)
        {
            shotsTimer -= Time.deltaTime;

            if (shotsTimer < 0)
            {
                isReadyToShoot = true;
                shotsTimer = timerStart;
            }
        }

        if (isReadyToShoot)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(playerBullet, new Vector3(bulletSpawnLocation.transform.position.x, transform.position.y + 0.5f,
                    bulletSpawnLocation.transform.position.z), this.transform.rotation);
                isReadyToShoot = false;
            }
        }
    }

}
