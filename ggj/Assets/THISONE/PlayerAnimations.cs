using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;

    [SerializeField] private GameObject player;

    float threshold;

    private void Start()
    {
        threshold = 0.1f;
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("Idle", true);
    }

    private void Update()
    {
        if (!Input.anyKey)
        {
            playerAnimator.SetBool("Walking", false);
            playerAnimator.SetBool("Dashing", false);
            playerAnimator.SetBool("Idle", true);
            playerAnimator.SetBool("Attacking", false);

        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Dash();
            }

            playerAnimator.SetBool("Walking", true);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attacking", false);

        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            playerAnimator.SetBool("Walking", false);
            playerAnimator.SetBool("Dashing", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attacking", true);
        }
        else
        {
            playerAnimator.SetBool("Attacking", false);
        }
        Dash();

    }
    public void ReturnToWalking()
    {
        playerAnimator.SetBool("Dashing", false);
        playerAnimator.SetBool("Walking", true);
        playerAnimator.SetBool("Idle", false);
        playerAnimator.SetBool("Attacking", false);

    }
    private void Dash()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerAnimator.SetBool("Dashing", true);
            playerAnimator.SetBool("Walking", false);
            playerAnimator.SetBool("Idle", false);
            playerAnimator.SetBool("Attacking", false);

        }
    }
}

