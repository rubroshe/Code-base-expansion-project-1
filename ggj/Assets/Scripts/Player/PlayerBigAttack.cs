using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBigAttack : MonoBehaviour
{
    [SerializeField] private GameObject playerBigBullet;
    [SerializeField] private GameObject bigBulletSpawnLocation;

    private bool BBIsReadyToShoot;

    [Header("Timer between shots")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float bigShotsTimer;

    private float bigTimerStart;
    private void Awake()
    {
        bigTimerStart = bigShotsTimer;
    }
    private void Start()
    {
        BBIsReadyToShoot = true;
        bigBulletSpawnLocation = GameObject.FindGameObjectWithTag("BulletSpawnLocation");
    }

    void Update()
    {
        if (!BBIsReadyToShoot)
        {
            bigShotsTimer -= Time.deltaTime;

            if (bigShotsTimer < 0)
            {
                BBIsReadyToShoot = true;
                bigShotsTimer = bigTimerStart;
            }
        }

        if (BBIsReadyToShoot)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(playerBigBullet, new Vector3(bigBulletSpawnLocation.transform.position.x, transform.position.y + 0.5f,
                    bigBulletSpawnLocation.transform.position.z), this.transform.rotation);
                BBIsReadyToShoot = false;
            }
        }
    }

}
