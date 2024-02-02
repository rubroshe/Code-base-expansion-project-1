using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public PlayerHealth playerHealth;
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerMovement player;

    [Header("Damage From Enemy")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemy;

    [Header("Damage From Spikes")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromSpike;

    [Header("Damage From Vines")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromVines;

    [Header("Damage From Enemy Bullet")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemyBullet;

    [Header("Damage From Enemy Cloud")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float damageFromEnemyCloud;

    [Header("Health Pickup Total")]
    [Space]
    [Range(0.0f, 100.0f)]
    [SerializeField] float healthPickupTotal;

    bool hasRan;
    public bool isDashing;
    public bool isCharging;
    private bool isReadyToShoot;
    private bool HasCharged;

    public float playerHP;
    private float timerStart;
    private Rigidbody rb;
    private float timerSave;

  //  [SerializeField] private GameObject location;
    [SerializeField] private GameObject trail;
    [SerializeField] public GameObject playerBullet;
    [SerializeField] public GameObject bulletSpawnLocation;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float moveSpeed;

    [Range(0.0f, 100.0f)]
    [SerializeField] private float dashSpeed;

    [Range(0.0f, 5.0f)]
    [SerializeField] private float stopDash_Timer;

    [Range(0.0f, 5.0f)]
    [SerializeField] private float resetDash_Timer;





    [Header("Regular Bullet Variables")]
    [Header("Timer between shots")]
    [Space]
    [Range(0.0f, 20.0f)]
    [SerializeField] public float bulletDamage;

    

    [Header("Timer between shots")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float shotsTimer;
   
   

   

    [Header("Timer to enable Increase Attack")]
    [Space]
    [Range(0.0f, 10.0f)]
    [SerializeField] private float timer;

    [SerializeField] private GameObject respawn;


    [Header("Big Bullet Variables")]
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
        timerStart = shotsTimer;
        timerSave = timer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            AddHealthPickup();
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "MyGameObjectName")
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            gameObject.transform.position = new Vector3(respawn.transform.position.x, respawn.transform.position.y,
                respawn.transform.position.z);

            TakeDamageFromSpike();
        }

        if (collision.gameObject.CompareTag("Vines"))
        {
            TakeDamageFromVines();
        }

    }

    private void Start()
    {
        BBIsReadyToShoot = true;
        bigBulletSpawnLocation = GameObject.FindGameObjectWithTag("BulletSpawnLocation");
        playerHP = 100;

        rb = GetComponent<Rigidbody>();
        isDashing = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {

        Rotation();

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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(playerBullet, new Vector3(bulletSpawnLocation.transform.position.x, transform.position.y + 0.5f,
                    bulletSpawnLocation.transform.position.z), this.transform.rotation);
                isReadyToShoot = false;
            }
        }

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
        else if (Input.GetKeyUp(KeyCode.E) && !hasRan)
        {
            ResetValues();
        }


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

    void FixedUpdate()
    {
        if (isCharging) { return; }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // FIXED transform.Translate(new Vector3(x, 0, z) * (moveSpeed * Time.deltaTime));
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
            // FIXED rb.AddForce(this.transform.forward * dashSpeed, ForceMode.Impulse);
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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(playerBullet, new Vector3(bulletSpawnLocation.transform.position.x, transform.position.y + 0.5f,
                    bulletSpawnLocation.transform.position.z), this.transform.rotation);
                isReadyToShoot = false;
            }
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

    

    private void OnTriggerEnter(Collider other)
    {
        if (player.isDashing)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                playerHP = playerHP - damageFromEnemy;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyCloud"))
        {
            playerHP = playerHP - damageFromEnemyCloud * Time.deltaTime;
        }
    }

    public void TakeDamageFromSpike()
    {
        playerHP = playerHP - damageFromSpike;
    }
    public void TakeDamageFromVines()
    {
        playerHP = playerHP - damageFromVines;
    }
    public void TakeDamageFromEnemyBullet()
    {
        playerHP = playerHP - damageFromEnemyBullet;
    }

    public void AddHealthPickup()
    {
        if (playerHP > 100)
        {
            return;
        }
        playerHP = playerHP + healthPickupTotal;
    }


    private void Rotation()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));
    }

    
}
