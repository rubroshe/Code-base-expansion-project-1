using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private BossAOE bossAOE;
    [SerializeField] private BossSprayBullets bossSpray;

    [Header("Time Between Switch to Boss Spray")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timeBetweenSwtichToBossSpray;

    [Header("Time Between Switch to AOE Spray")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timeBetweenSwtichToAOE;

    float saveAOETimer;
    float saveBossStrayTimer;

    private void Start()
    {
        saveAOETimer = timeBetweenSwtichToAOE;
        saveBossStrayTimer = timeBetweenSwtichToBossSpray;
    }

    private void Update()
    {
        if(bossSpray.enabled)
        {
            timeBetweenSwtichToBossSpray -= Time.deltaTime;
        }

        if (bossAOE.enabled)
        {
            timeBetweenSwtichToAOE -= Time.deltaTime;
        }

        if (timeBetweenSwtichToBossSpray < 0 && !bossAOE.enabled)
        {
            timeBetweenSwtichToAOE = saveAOETimer;
            bossAOE.enabled = !bossAOE.enabled;
            bossSpray.enabled = !bossSpray.enabled;
        }

        if (timeBetweenSwtichToAOE < 0 && !bossSpray.enabled)
        {
            timeBetweenSwtichToBossSpray = saveBossStrayTimer;
            bossAOE.enabled = !bossAOE.enabled;
            bossSpray.enabled = !bossSpray.enabled;
        }
    }
}
