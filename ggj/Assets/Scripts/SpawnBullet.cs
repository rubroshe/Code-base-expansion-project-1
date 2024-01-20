using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private GameObject SpawnedProjectile;
    private bool shooting = false;

    [Range(0f, 10.0f)]
    [SerializeField] private float SecondBetweenShots = 0.5f;

    [SerializeField] private float Radius;

    void Start()
    {
        shooting = true;
    }

    private void ProjectileList()
    {
        //float distance = 

        if(shooting)
        {
            GameObject projectile_Clone = Instantiate(SpawnedProjectile, this.transform.position, Quaternion.Euler(this.transform.rotation.eulerAngles)) as GameObject;

            shooting = false;

            StartCoroutine(resetShots());
        }
    }

    private void Update()
    {
        ProjectileList();
    }

    IEnumerator resetShots()
    {
        yield return new WaitForSeconds(SecondBetweenShots);

        shooting = true;
    }
}
