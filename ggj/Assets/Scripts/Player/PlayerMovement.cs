using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float moveSpeed;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float dashSpeed;

    [Range(0.0f, 5.0f)]
    [SerializeField] private float stopDash_Timer;

    [Range(0.0f, 5.0f)]
    [SerializeField] private float resetDash_Timer;

    [SerializeField] private GameObject trail;

    public bool isDashing;
    public bool isCharging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDashing = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isCharging) { return; }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // FIX THIS transform.Translate(new Vector3(x, 0, z) * (moveSpeed * Time.deltaTime));
        Vector3 moveDirection = new Vector3(x, 0, z).normalized;
        // moveDirection.Normalize();

        /*// convert to world space
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);*/

        // apply in world space
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.deltaTime));

        if (Input.GetKey(KeyCode.Space) && isDashing)
        {
            trail.SetActive(true);
             // FIX THIS rb.AddForce(this.transform.forward * dashSpeed, ForceMode.Impulse);
            if (moveDirection != Vector3.zero)
            {
                rb.AddForce(moveDirection * dashSpeed, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
            }
            
            isDashing = false;
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        yield return new WaitForSeconds(stopDash_Timer);
        rb.velocity = new Vector3(0, 0, 0);

        StartCoroutine(resetDash());
    }

    IEnumerator resetDash()
    {
        yield return new WaitForSeconds(resetDash_Timer);
        trail.SetActive(false);
        isDashing = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MyGameObjectName")
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}