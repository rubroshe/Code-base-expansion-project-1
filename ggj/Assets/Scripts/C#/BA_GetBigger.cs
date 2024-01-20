using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_GetBigger : MonoBehaviour
{
    [Header("Max Scale of AOE")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float Max;

    [Header("Timer for Sphere")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timerForSphere;

    [Header("Timer for Particle System")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timerForParticleSystem;

    [SerializeField] GameObject _particleSystem;


    void Update()
    {

        if (transform.localScale.x <= Max)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 2, transform.localScale.y + Time.deltaTime * 2,
                transform.localScale.z + Time.deltaTime * 2);
        }
        
        if(transform.localScale.x >= Max - 3)
        {
            _particleSystem.SetActive(true);

            if (timerForSphere > 0)
            {
                timerForSphere -= Time.deltaTime;
            }
            if (timerForSphere < 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;

                if (timerForParticleSystem > 0)
                {
                    timerForParticleSystem -= Time.deltaTime;
                }
                if (timerForParticleSystem < 0)
                {
                    Destroy(gameObject);
                }
            }

        }
    }

}