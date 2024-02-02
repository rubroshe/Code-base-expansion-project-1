using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSprayBullets : MonoBehaviour
{
    [SerializeField] private GameObject BossBullet;
    [SerializeField] private GameObject BulletSpawnLocation;

    private bool isReadyToShoot;

    float timer;

    [Header("Bullet Time")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float BulletTime;

    private void Awake()
    {
        isReadyToShoot = true;
        timer = BulletTime;
    }

    private void Update()
    {
        if (BulletTime < 0)
        {
            BulletTime = timer;
            isReadyToShoot = true;
        }
        BulletTime -= Time.deltaTime;

        if (isReadyToShoot)
        {
            Instantiate(BossBullet, new Vector3(BulletSpawnLocation.transform.position.x, transform.position.y - .5f,
                BulletSpawnLocation.transform.position.z), Quaternion.identity);
            isReadyToShoot = false;
        }
    }
}
