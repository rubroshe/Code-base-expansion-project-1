using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAttackBonus : MonoBehaviour
{
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Timer to enable Increase Attack")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timer;

    private float timerSave;

    private bool hasRan;
    private bool HasCharged;

    private void Awake()
    {
        timerSave = timer;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && HasCharged == false)
        {
            timer -= Time.deltaTime;
            playerMovement.isCharging = true;

            if (timer < 0 && !hasRan)
            {
                HasCharged = true;
                playerMovement.isCharging = false;
                playerShooting.bulletDamage = playerShooting.bulletDamage * 2;
                StartCoroutine(HowLongIncreasedAttackLasts());
                hasRan = true;
            }
            else
            {
                hasRan = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.E) && !hasRan)
        {
            ResetValues();
        }
    }

    private void ResetValues()
    {
        playerMovement.isCharging = false;
        hasRan = false;
        timer = timerSave;
        HasCharged = false;
    }

    IEnumerator HowLongIncreasedAttackLasts()
    {
        yield return new WaitForSeconds(5);
        playerShooting.bulletDamage = playerShooting.bulletDamage / 2;
        hasRan = false;
        timer = timerSave;
        HasCharged = false;
    }
}
